using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace HueInvaders.Shared.Screens
{
    public interface IScreen
    {
        void Reset();
        void HandleInput(TouchCollection previousTouchCollection, TouchCollection currentTouchCollection, GameTime gameTime);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
