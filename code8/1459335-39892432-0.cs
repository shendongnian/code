     repeat = Content.Load<Texture2D>("repeat");
     repeat1 = Content.Load<Texture2D>("repeat1");
     repeat2 = Content.Load<Texture2D>("repeat2");
    
    public override void Draw(GameTime gameTime)
    {
    SpriteBatch.Begin();
    if (random == 0)
    {
    SpriteBatch.Draw(repeat, Position, Color);
    }
    else if (random == 1)
    {
    SpriteBatch.Draw(repeat1, Position, Color);
    }
    else if (random == 2)
    {
    SpriteBatch.Draw(repeat2, Position, Color);
    }
    SpriteBatch.End();
    }
