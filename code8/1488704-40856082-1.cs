    private void OnLoad(EventArgs e)
    {
         myTimer.Tick += new EventHandler(TimerEventProcessor);
    }
    private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
    {
        MyBusinessObject o = GetMyBusinessObject();
        TimeSpan ts = o.ElapsedTime;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        this.lblTimeElapsed.Text = elapsedTime;
    }
    
