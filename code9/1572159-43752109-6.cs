    protected override void OnResize(EventArgs eventargs)
    {
        base.OnResize(eventargs);
        if (this.Width < 420)
            this.Size = new Size(420, 236);
        else
            this.Size = new Size(this.Width, (int)(this.Width * 9.0 / 16));
    }
