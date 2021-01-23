        #region Usings
    
    using System.IO;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    
    #endregion
    
    namespace OpacityTest
    {
        /// <summary>
        ///     This is the main type for your game
        /// </summary>
        public class Game1 : Game
        {
            private static Texture2D Tested;
            private GraphicsDeviceManager graphics;
            private SpriteBatch spriteBatch;
    
            public Game1()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
    
            /// <summary>
            ///     Allows the game to perform any initialization it needs to before starting to run.
            ///     This is where it can query for any required services and load any non-graphic
            ///     related content.  Calling base.Initialize will enumerate through any components
            ///     and initialize them as well.
            /// </summary>
            protected override void Initialize()
            {
                // TODO: Add your initialization logic here
    
                base.Initialize();
            }
    
            /// <summary>
            ///     LoadContent will be called once per game and is the place to load
            ///     all of your content.
            /// </summary>
            protected override void LoadContent()
            {
                // Create a new SpriteBatch, which can be used to draw textures.
                spriteBatch = new SpriteBatch(GraphicsDevice);
    
                using (var fileStream = new FileStream("test.png", FileMode.Open))
                {
                    Tested = Texture2D.FromStream(GraphicsDevice, fileStream);
                }
            }
    
            /// <summary>
            ///     UnloadContent will be called once per game and is the place to unload
            ///     all content.
            /// </summary>
            protected override void UnloadContent()
            {
                // Important!!!
                Tested.Dispose();
            }
    
            /// <summary>
            ///     Allows the game to run logic such as updating the world,
            ///     checking for collisions, gathering input, and playing audio.
            /// </summary>
            /// <param name="gameTime">Provides a snapshot of timing values.</param>
            protected override void Update(GameTime gameTime)
            {
                // Allows the game to exit
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    Exit();
    
                base.Update(gameTime);
            }
    
            /// <summary>
            ///     This is called when the game should draw itself.
            /// </summary>
            /// <param name="gameTime">Provides a snapshot of timing values.</param>
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
    
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                spriteBatch.Draw(Tested, Vector2.Zero, Color.White);
                spriteBatch.End();
    
                base.Draw(gameTime);
            }
        }
    }
