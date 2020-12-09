using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Star_Field
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Random random = new Random();
        List<Star> starList;

        int screenWidth;
        int screenHeight;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            // TODO: Add your initialization logic here
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;
            starList = new List<Star>();
            for (int i = 0; i < 100; i++)
            {
                starList.Add(new Star(Content, screenWidth, screenHeight, random));
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            //If a star goes of screen add a new one
            for (int i = 0; i < starList.Count; i++)
            {
                Rectangle starRectangle = starList[i].Update();
                if (starRectangle.X >= screenWidth + 10 || starRectangle.X <= -10)
                {
                    starList.Remove(starList[i]);
                    starList.Add(new Star(Content, screenWidth, screenHeight, random));
                }
                if (starRectangle.Y >= screenHeight + 10 || starRectangle.Y <= -10)
                {
                    starList.Remove(starList[i]);
                    starList.Add(new Star(Content, screenWidth, screenHeight, random));
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
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            //For each star call the draw method
            for (int i = 0; i < starList.Count; i++)
            {
                starList[i].Draw(graphics.GraphicsDevice);
            }
 
            base.Draw(gameTime);
        }
    }
}
