using System;
using Microsoft.Xna.Framework;

namespace HueInvaders.Shared.Models.Interfaces
{
    public interface IProjectile : IGameObject
    {
        bool Active { get; set; }
        void Fire(Vector2 position, Vector2 direction);
    }
}
