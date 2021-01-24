    private static void SetTimer()
    {
        aTimer = new System.Timers.Timer(DefaultTick);
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }
