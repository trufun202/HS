using System;
using HueInvaders.Shared.Handlers;
using HueInvaders.Shared.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HueInvaders.Shared.Background.Components
{
    public class StarBig : IBackgroundEffectComponent
    {
        private Vector2 Position;
        private Vector2 Direction = new Vector2(0, 1);
        private int Speed = 0;
        private int SpeedMin = 1750;
        private int SpeedMax = 4000;

        public StarBig()
        {
            Position = new Vector2()
            {
                X = Utilities.GetRandomInt(0, Defaults.GraphicsWidth),
                Y = Utilities.GetRandomInt(-128, Defaults.GraphicsHeight)
            };

            Speed = Utilities.GetRandomInt(SpeedMin, SpeedMax);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ContentHandler.Images["WhiteDot"], new Rectangle((int)Position.X, (int)Position.Y, 8, 128), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Position.Y > Defaults.GraphicsHeight)
            {
                Position.Y = 0;
            }
        }
    }
}
