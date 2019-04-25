using System;
using System.Collections.Generic;
using HueInvaders.Shared.Background.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HueInvaders.Shared.Background
{
    public class HyperSpace : IBackground
    {
        public HyperSpace()
        {
        }

        private List<StarBig> Stars = new List<StarBig>();

        public HyperSpace(int starCount)
        {
            for (int i = 0; i < starCount; i++)
            {
                Stars.Add(new StarBig());
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
