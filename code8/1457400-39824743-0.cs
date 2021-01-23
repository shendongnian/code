    private Texture2D starPic600Texture;
    private Rectangle starPic600Rect;
    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        starPic600Rect = new Rectangle(30,20,600,600);
        starPic600Texture = this.Content.Load<Texture2D>("starPic600");
    }
