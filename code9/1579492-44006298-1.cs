    private void EnableUITimer()
    {
        if (UITimer == null)
        {
            UITimer = new Timer();
            UITimer.Interval = intervalInMillis;
            UITimer.Start();
        }
        UITimer.Elapsed += UITimer_Elapsed;        
    }
