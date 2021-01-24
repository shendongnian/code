    private static Timer timer;
    public void DoStuff()
    {
        var intervalMs = 5000;
        timer = new System.Timers.Timer();
        timer.Interval = intervalMs;
        timer.Elapsed += DoStuffOnTimer;
        timer.Enabled  = true;
    }
    private static void DoStuffOnTimer(Object source, System.Timers.ElapsedEventArgs e)
    {
        //do stuff
    }
