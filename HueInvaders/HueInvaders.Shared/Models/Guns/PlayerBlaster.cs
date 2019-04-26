using System;
using System.Collections.Generic;
using HueInvaders.Shared.Models.Interfaces;
using HueInvaders.Shared.Models.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace HueInvaders.Shared.Models.Guns
{
    public class PlayerBlaster : IGun
    {
        private List<IProjectile> Projectiles;
        private TimedEvent ProjectileCooldownEvent;
        private bool CanShoot = true;

        public PlayerBlaster(int projectileCount, Type projectileType, int cooldown)
        {
            Projectiles = new List<IProjectile>();
            for (int i = 0; i < projectileCount; i++)
            {
                if (projectileType == typeof(BulletOne))
                {
                    Projectiles.Add(new BulletOne());
                }
                else
                {
                    Projectiles.Add(new BulletOne());
                }
            }

            ProjectileCooldownEvent = new TimedEvent(cooldown, () =>
            {
                CanShoot = true;
            }, -1);
        }

        public void Fire(Vector2 position, Vector2 direction)
        {
            if (CanShoot)
            {
                var bullet1 = GetNextProjectile();
                var bullet2 = GetNextProjectile();

                if (bullet1 != null && bullet2 != null)
                {
                    bullet1.Fire(new Vector2(position.X - 40, position.Y - 35), direction);
                    bullet2.Fire(new Vector2(position.X + 40, position.Y - 35), direction);
                    CanShoot = false;
                }

                ProjectileCooldownEvent.Reset();
            }
        }

        private IProjectile GetNextProjectile()
        {
            foreach(var projectile in Projectiles)
            {
                if (!projectile.Active)
                {
                    projectile.Active = true;
                    return projectile;
                }
            }

            return null;
        }

        public void HandleInput(TouchCollection previousTouchCollection, TouchCollection currentTouchCollection, GameTime gameTime)
        {

        }

        public void Update(GameTime gameTime)
        {
            if (!CanShoot)
            {
                ProjectileCooldownEvent.Update(gameTime);
            }

            foreach (var projectile in Projectiles)
            {
                projectile.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var projectile in Projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }
    }
}
