    public void InitTimer()
    {
        if (dispatcherTimer != null)
        {
            dispatcherTimer.Tick -= dispatcherTimer_Tick;
        }
        dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Tick += dispatcherTimer_Tick;
        dispatcherTimer.Interval = new TimeSpan(0, Convert.ToInt32(textBox.Text), 0);
        dispatcherTimer.Start();
    }
