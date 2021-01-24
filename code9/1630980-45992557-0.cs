    void Run(double frameRate, double updateRate)
    {
        // pre-timer initialization code.
        RenderTimer.Interval = Convert.ToInt32(1000 / frameRate);
        RenderTimer.Tick += RenderTick;
        RenderTimer.Start();
        UpdateTimer.Interval = Convert.ToInt32(1000 / updateRate);
        UpdateTimer.Tick += UpdateTick;
        UpdateTimer.Start();
        // post-timer initialization code.
        Running = true;
    }
    // ...
    protected override void OnVisibleChanged(EventArgs e)
    {
        // ...
        // Remove timer intialization from here.
        // ...
    }
