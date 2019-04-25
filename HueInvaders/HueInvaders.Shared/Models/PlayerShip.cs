using System;
using HueInvaders.Shared.Handlers;
using HueInvaders.Shared.Models.Interfaces;
using HueInvaders.Shared.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace HueInvaders.Shared.Models
{
    public class PlayerShip : IGameObject
    {
        private Vector2 Position = Vector2.Zero;

        public PlayerShip()
        {
            Reset();
        }

        public void Reset()
        {
            Position.X = Defaults.GraphicsWidth / 2;
            Position.Y = Defaults.GraphicsHeight / 2;
        }

        public void HandleInput(TouchCollection previousTouchCollection, TouchCollection currentTouchCollection, GameTime gameTime)
        {
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ContentHandler.Images["Player_1"], Position, Player.CurrentColor);
        }
    }
}
