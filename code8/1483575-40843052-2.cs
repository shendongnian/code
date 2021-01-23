    public event EventHandler Click;
    
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if(this.Click != null)
            Click(null, null);
    }
