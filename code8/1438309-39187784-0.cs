    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    
    namespace Game1
    {
        public class Game1 : Game
        {
            private BasicEffect _basicEffect;
            private GraphicsDeviceManager _graphics;
    
    
            public Game1()
            {
                _graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
    
            protected override void Initialize()
            {
                _basicEffect = new BasicEffect(GraphicsDevice) {VertexColorEnabled = true};
                base.Initialize();
            }
    
    
            protected override void Update(GameTime gameTime)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                    Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                base.Update(gameTime);
            }
    
            private void DrawSquare(BasicEffect basicEffect, Vector2 position, Vector2 size, Color tint)
            {
                // square made out of 2 triangles
                var colors = new[]
                {
                    new VertexPositionColor(new Vector3(-0.5f, -0.5f, 0.0f), Color.White),
                    new VertexPositionColor(new Vector3(+0.5f, -0.5f, 0.0f), Color.White),
                    new VertexPositionColor(new Vector3(+0.5f, +0.5f, 0.0f), Color.White),
                    new VertexPositionColor(new Vector3(-0.5f, -0.5f, 0.0f), Color.White),
                    new VertexPositionColor(new Vector3(+0.5f, +0.5f, 0.0f), Color.White),
                    new VertexPositionColor(new Vector3(-0.5f, +0.5f, 0.0f), Color.White)
                };
    
                basicEffect.World = // NOTE: the correct order for matrices is SRT (scale, rotate, translate)
                    Matrix.CreateTranslation(0.5f, 0.5f, 0.0f)* // offset by half pixel to get pixel perfect rendering
                    Matrix.CreateScale(size.X, size.Y, 1.0f)* // set size
                    Matrix.CreateTranslation(position.X, position.Y, 0.0f)* // set position
                    Matrix.CreateOrthographicOffCenter // 2d projection
                        (
                            0.0f,
                            GraphicsDevice.Viewport.Width, // NOTE : here not an X-coordinate (i.e. width - 1)
                            GraphicsDevice.Viewport.Height,
                            0.0f,
                            0.0f,
                            1.0f
                        );
    
                // tint it however you like
                basicEffect.DiffuseColor = tint.ToVector3();
    
                var passes = _basicEffect.CurrentTechnique.Passes;
                foreach (var pass in passes)
                {
                    pass.Apply();
                    GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, colors, 0, colors.Length/3);
                }
            }
    
            /// <summary>
            ///     This is called when the game should draw itself.
            /// </summary>
            /// <param name="gameTime">Provides a snapshot of timing values.</param>
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
    
                DrawSquare(_basicEffect, new Vector2(10, 10), new Vector2(100, 100), Color.Red);
                DrawSquare(_basicEffect, new Vector2(200, 200), new Vector2(50, 50), Color.Green);
    
                base.Draw(gameTime);
            }
        }
    }
