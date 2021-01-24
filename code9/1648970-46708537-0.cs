    public void UpdateTimer(GameTime gameTime)
    {
        timer += gameTime.ElapsedGameTime;
        Debug.WriteLine("Timer: " + timer.Milliseconds);
    }
