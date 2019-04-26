using System;
using System.Collections.Generic;
using HueInvaders.Shared.Handlers;
using HueInvaders.Shared.Models.Guns;
using HueInvaders.Shared.Models.Interfaces;
using HueInvaders.Shared.Models.Projectiles;
using HueInvaders.Shared.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace HueInvaders.Shared.Models
{
    public class PlayerShip : IGameObject
    {
        private Vector2 Position = Vector2.Zero;
        private int PROJECTILE_COUNT = 40;
        private IGun Gun;
        private double ScaleX = 0;
        private double ScaleY = 0;

        public PlayerShip(double scaleX, double scaleY)
        {
            ScaleX = scaleX;
            ScaleY = scaleY;
            Reset();
        }

        public void Reset()
        {
            Gun = new PlayerBlaster(PROJECTILE_COUNT, typeof(BulletOne), 100);
            Position.X = Defaults.GraphicsWidth / 2;
            Position.Y = Defaults.GraphicsHeight / 2;
        }

        public void HandleInput(TouchCollection previousTouchCollection, TouchCollection currentTouchCollection, GameTime gameTime)
        {
            if (currentTouchCollection.Count > 0 && (currentTouchCollection[0].Position.Y / ScaleY) < Defaults.GraphicsHeight - ContentHandler.Images["ColorButton_Off"].Height)
            {
                Gun.Fire(new Vector2(Position.X, Position.Y), new Vector2(0, -1));

                Position = new Vector2((int)(currentTouchCollection[0].Position.X / ScaleX), (int)(currentTouchCollection[0].Position.Y / ScaleY));
            }
        }

        public void Update(GameTime gameTime)
        {
            Gun.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ContentHandler.Images["Player_1"],
                new Rectangle((int)Position.X, (int)Position.Y, ContentHandler.Images["Player_1"].Width, ContentHandler.Images["Player_1"].Height),
                null,
                Player.CurrentColor,
                0f,
                new Vector2((int)(ContentHandler.Images["Player_1"].Width / (double)2), (int)(ContentHandler.Images["Player_1"].Height / (double)2)),
                SpriteEffects.None,
                1f);
            Gun.Draw(spriteBatch);
        }
    }
}
