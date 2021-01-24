    // somewhere before Run(ideally in the initialization of the main form).
    RenderTimer.Interval = Convert.ToInt32(1000 / frameRate);
    RenderTimer.Tick += RenderTick;
    UpdateTimer.Interval = Convert.ToInt32(1000 / updateRate);
    UpdateTimer.Tick += UpdateTick;
    
    void Run(double frameRate, double updateRate)
    {
        // ...
        RenderTimer.Start();
        UpdateTimer.Start();
        // ...
        Running = true;
    }
    // ...
    protected override void OnVisibleChanged(EventArgs e)
    {
        // ...
        // Don't initialize timers here.
        // ...
    }
