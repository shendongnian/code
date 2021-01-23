    public event EventHandler Click;
    
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        this.Click += DynamicButton_Click; // Called 60 times per frame on a PC!
    }
