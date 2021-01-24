    public void InitTimer()
    {
        if (dispatcherTimer != null)
        {
            dispatcherTimer.Tick -= dispatcherTimer_Tick;
            dispatcherTimer.Stop();
        }
