    class Player : Game
    {
        Texture2D PlayerSprite;
        Vector2 PlayerPosition;
		SpriteBatch spriteBatch;
        public Player()
        {
            Content.RootDirectory = "Content";
            PlayerSprite = Content.Load<Texture2D>("spr_Player");
            PlayerPosition = Vector2.Zero;
        }
		
		protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
		}
        protected override void Update(GameTime gameTime)
        {
        }
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(PlayerSprite,PlayerPosition, new Rectangle(0, 0, 32,32), Color.White);
            spriteBatch.End();
        }
    }
