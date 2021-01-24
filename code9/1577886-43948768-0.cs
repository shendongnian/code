    protected override void Draw(GameTime gameTime)
    {
        // move this here
        graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();
        ScreenManager.Instance.Draw(spriteBatch);
        spriteBatch.End();
        base.Draw(gameTime);
    }
