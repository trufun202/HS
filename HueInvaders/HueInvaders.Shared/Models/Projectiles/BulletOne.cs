using System;
using HueInvaders.Shared.Handlers;
using HueInvaders.Shared.Models.Interfaces;
using HueInvaders.Shared.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace HueInvaders.Shared.Models.Projectiles
{
    public class BulletOne : IProjectile
    {
        Vector2 Position = Vector2.Zero;
        private Vector2 Direction = Vector2.Zero;
        private int Speed = 1000;
        private bool Shooting = false;

        public bool Active { get; set; }

        public BulletOne()
        {
            Active = false;
        }

        public void Fire(Vector2 position, Vector2 direction)
        {
            Active = true;
            Position = position;
            Direction = direction;
            Shooting = true;
        }

        public void HandleInput(TouchCollection previousTouchCollection, TouchCollection currentTouchCollection, GameTime gameTime)
        {

        }

        public void Update(GameTime gameTime)
        {
            if (Shooting)
            {
                Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if ((Direction.Y > 0 && Position.Y > Defaults.GraphicsHeight)
                    || (Direction.Y < 0 && Position.Y < ContentHandler.Images["Laser_1"].Height * -1))
                {
                    Shooting = false;
                    Active = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var flip = SpriteEffects.None;

            if (Direction.Y < 0)
            {
                flip = SpriteEffects.FlipHorizontally;
            }

            spriteBatch.Draw(ContentHandler.Images["Laser_1"], new Rectangle((int)Position.X, (int)Position.Y, ContentHandler.Images["Laser_1"].Width, ContentHandler.Images["Laser_1"].Height), null, Player.CurrentColor, 0f, new Vector2((int)(ContentHandler.Images["Laser_1"].Width / (double)2), (int)(ContentHandler.Images["Laser_1"].Height / (double)2)), flip, 1f);
        }
    }
}
