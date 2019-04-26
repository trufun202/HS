using System;
using HueInvaders.Shared.Forms;
using HueInvaders.Shared.Handlers;
using HueInvaders.Shared.Models;
using HueInvaders.Shared.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace HueInvaders.Shared.Screens
{
    public class GamePlayScreen : IScreen
    {
        PlayerShip playerShip;
        Form FormColors;

        public GamePlayScreen(double scaleX, double scaleY)
        {
            playerShip = new PlayerShip(scaleX, scaleY);
            FormColors = new Form(0, 0);

            FormColors.Controls.Add(new Button(new Rectangle(0, Defaults.GraphicsHeight - ContentHandler.Images["ColorButton_On"].Height, ContentHandler.Images["ColorButton_On"].Width, ContentHandler.Images["ColorButton_On"].Height), () =>
            {
                if (!Player.RedOn)
                {
                    Player.RedOn = true;
                    ContentHandler.Sounds["Picker_Up"].Play();
                }
                else
                {
                    Player.RedOn = false;
                    ContentHandler.Sounds["Picker_Down"].Play();
                }
                return true;
            }, string.Empty, scaleX, scaleY));
            FormColors.Controls.Add(new Button(new Rectangle(ContentHandler.Images["ColorButton_On"].Width + 16, Defaults.GraphicsHeight - ContentHandler.Images["ColorButton_On"].Height, ContentHandler.Images["ColorButton_On"].Width, ContentHandler.Images["ColorButton_On"].Height), () =>
            {
                if (!Player.BlueOn)
                {
                    Player.BlueOn = true;
                    ContentHandler.Sounds["Picker_Up"].Play();
                }
                else
                {
                    Player.BlueOn = false;
                    ContentHandler.Sounds["Picker_Down"].Play();
                }
                return true;
            }, string.Empty, scaleX, scaleY));
            FormColors.Controls.Add(new Button(new Rectangle(Defaults.GraphicsWidth - ContentHandler.Images["ColorButton_On"].Width, Defaults.GraphicsHeight - ContentHandler.Images["ColorButton_On"].Height, ContentHandler.Images["ColorButton_On"].Width, ContentHandler.Images["ColorButton_On"].Height), () =>
            {
                if (!Player.YellowOn)
                {
                    Player.YellowOn = true;
                    ContentHandler.Sounds["Picker_Up"].Play();
                }
                else
                {
                    Player.YellowOn = false;
                    ContentHandler.Sounds["Picker_Down"].Play();
                }
                return true;
            }, string.Empty, scaleX, scaleY));
        }

        public void Reset()
        {
            playerShip.Reset();
            FormColors.Ready = true;
        }

        public void HandleInput(TouchCollection previousTouchCollection, TouchCollection currentTouchCollection, GameTime gameTime)
        {
            playerShip.HandleInput(previousTouchCollection, currentTouchCollection, gameTime);
            FormColors.HandleInput(previousTouchCollection, currentTouchCollection, gameTime);
        }

        public void Update(GameTime gameTime)
        {
            playerShip.Update(gameTime);
            FormColors.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerShip.Draw(spriteBatch);

            if (Player.RedOn)
            {
                spriteBatch.Draw(ContentHandler.Images["ColorButton_On"], new Vector2(0, Defaults.GraphicsHeight - ContentHandler.Images["ColorButton_On"].Height), Defaults.Red);
            }
            else
            {
                spriteBatch.Draw(ContentHandler.Images["ColorButton_Off"], new Vector2(0, Defaults.GraphicsHeight - ContentHandler.Images["ColorButton_On"].Height), Defaults.Red);
            }

            if (Player.BlueOn)
            {
                spriteBatch.Draw(ContentHandler.Images["ColorButton_On"], new Vector2(ContentHandler.Images["ColorButton_On"].Width + 16, Defaults.GraphicsHeight - ContentHandler.Images["ColorButton_On"].Height), Defaults.Blue);
            }
            else
            {
                spriteBatch.Draw(ContentHandler.Images["ColorButton_Off"], new Vector2(ContentHandler.Images["ColorButton_On"].Width + 16, Defaults.GraphicsHeight - ContentHandler.Images["ColorButton_On"].Height), Defaults.Blue);
            }

            if (Player.YellowOn)
            {
                spriteBatch.Draw(ContentHandler.Images["ColorButton_On"], new Vector2(Defaults.GraphicsWidth - ContentHandler.Images["ColorButton_On"].Width, Defaults.GraphicsHeight - ContentHandler.Images["ColorButton_On"].Height), Defaults.Yellow);
            }
            else
            {
                spriteBatch.Draw(ContentHandler.Images["ColorButton_Off"], new Vector2(Defaults.GraphicsWidth - ContentHandler.Images["ColorButton_On"].Width, Defaults.GraphicsHeight - ContentHandler.Images["ColorButton_On"].Height), Defaults.Yellow);
            }

            FormColors.Draw(spriteBatch);
        }
    }
}
