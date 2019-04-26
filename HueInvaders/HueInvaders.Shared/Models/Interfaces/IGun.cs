using System;
using Microsoft.Xna.Framework;

namespace HueInvaders.Shared.Models.Interfaces
{
    public interface IGun : IGameObject
    {
        void Fire(Vector2 position, Vector2 direction);
    }
}
