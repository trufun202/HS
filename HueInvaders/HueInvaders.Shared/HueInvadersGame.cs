#region Using Statements
using System;
using HueInvaders.Shared.Background;
using HueInvaders.Shared.Enums;
using HueInvaders.Shared.Handlers;
using HueInvaders.Shared.Models;
using HueInvaders.Shared.Screens;
using HueInvaders.Shared.ScreenTransitions;
using HueInvaders.Shared.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

#endregion

namespace HueInvaders
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class HueInvadersGame : Game
    {
        RenderTarget2D renderTarget;
        int ScreenHeight = 0;
        int ScreenWidth = 0;
        TouchCollection currentTouchCollection;
        TouchCollection previousTouchCollection;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        FadeTransition Fade;
        IBackground currentBackground;
        Screen CurrentScreen = Screen.Gameplay;
        GamePlayScreen GamePlayScreen;

        public HueInvadersGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.PreferredBackBufferWidth = ScreenWidth;

            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            renderTarget = new RenderTarget2D(
                graphics.GraphicsDevice,
                Defaults.GraphicsWidth,
                Defaults.GraphicsHeight,
                false,
                graphics.GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);

            var scaleX = (double)ScreenWidth / (double)Defaults.GraphicsWidth;
            var scaleY = (double)ScreenHeight / (double)Defaults.GraphicsHeight;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            Fade = new FadeTransition(Color.White, null);
            GamePlayScreen = new GamePlayScreen(scaleX, scaleY);
            GamePlayScreen.Reset();

            currentBackground = new StarField(100);

            previousTouchCollection = TouchPanel.GetState();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            ContentHandler.PreInit(Content);
            ContentHandler.Init(Content);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Fade.ShowingFade)
            {
                Fade.Update(gameTime);
            }
            else
            {
                ////////////////////////////////////////////////
                //HANDLE INPUT
                ////////////////////////////////////////////////
                currentTouchCollection = TouchPanel.GetState();

                if (CurrentScreen == Screen.Gameplay)
                {
                    GamePlayScreen.HandleInput(previousTouchCollection, currentTouchCollection, gameTime);
                }

                previousTouchCollection = currentTouchCollection;

                ////////////////////////////////////////////////
                //UPDATES
                ////////////////////////////////////////////////
                if (CurrentScreen == Screen.Gameplay)
                {
                    currentBackground.Update(gameTime);
                    GamePlayScreen.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.SetRenderTarget(renderTarget);
            graphics.GraphicsDevice.Clear(Defaults.SpaceBlue);
            spriteBatch.Begin();

            if (CurrentScreen == Screen.Gameplay)
            {
                currentBackground.Draw(spriteBatch);
                GamePlayScreen.Draw(spriteBatch);
            }

            if (Fade.ShowingFade)
            {
                Fade.Draw(spriteBatch);
            }

            spriteBatch.End();

            graphics.GraphicsDevice.SetRenderTarget(null);
            graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(renderTarget, new Rectangle(0, 0, ScreenWidth, ScreenHeight), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
