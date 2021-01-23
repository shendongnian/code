    internal void SetTimer(int interval) 
    {
        StopTimer();
        GameTimer = new DispatcherTimer();
        GameTimer.Tick += TimerCallback;
        GameTimer.Interval = new TimeSpan(0,0,0,0,interval);
        GameTimer.Start();
    }
    
    internal void StopTimer() 
    {
        if(GameTimer != null)
        {
            GameTimer.Stop();
            GameTimer.Tick -= TimerCallback;
            GameTimer = null;
        }
    }
