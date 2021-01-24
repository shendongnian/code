    private void EnableUITimer()
    {
        if (UITimer != null)
        {
            //  If it already exists, give it a handler from this instance. 
            //  Every instance that wants to be notified has to provide its own 
            //  event handler. 
            UITimer.Elapsed += UITimer_Elapsed;
            return;
        }
        UITimer = new Timer();
        UITimer.Interval = intervalInMillis;
        UITimer.Elapsed += UITimer_Elapsed;
        UITimer.Start();
    }
