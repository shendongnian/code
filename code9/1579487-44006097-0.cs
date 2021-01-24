    private void EnableUITimer()
    {
        if (UITimer != null)
        {
            return;
        }
        UITimer = new Timer();
        UITimer.Interval = intervalInMillis;
        UITimer.Elapsed += UITimer_Elapsed;
        UITimer.Start();
    }
