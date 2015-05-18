#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace rawr
{
	/// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
		SpriteFont sf;
		// teddy bear drawing support
		RubberChicken mushroom;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferHeight = 600;
			graphics.PreferredBackBufferWidth = 800;
            Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = false;	
			IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
				
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
			sf = Content.Load<SpriteFont> ("AngsanaUPC Regular 14.spriteFont");
            //TODO: use this.Content to load your game content here 
			mushroom = new RubberChicken (Content.Load<Texture2D> ("Mushroom2"), new Vector2 (200, 200), 3);

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
			{
				Exit();
			}
            // Update logic
			mushroom.update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
           	graphics.GraphicsDevice.Clear(Color.DarkRed);
		
            //TODO: Add your drawing code here
			spriteBatch.Begin ();
			spriteBatch.DrawString (sf, "hello world", new Vector2 (50, 50), Color.White);
			mushroom.Draw (spriteBatch);
			spriteBatch.End ();//calls enddraw which calls swapbuffers! yay for double buffering
            base.Draw(gameTime);
        }
    }
}

