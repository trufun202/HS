using System;
using System.Collections.Generic;
using HueInvaders.Shared.Background.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HueInvaders.Shared.Background
{
    public class StarField : IBackground
    {
        public StarField()
        {
        }

        private List<Star> Stars = new List<Star>();

        public StarField(int starCount)
        {
            for (int i = 0; i < starCount; i++)
            {
                Stars.Add(new Star());
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var star in Stars)
            {
                star.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var star in Stars)
            {
                star.Update(gameTime);
            }
        }
    }
}
