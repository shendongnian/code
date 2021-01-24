    DispatcherTimer dispatcherTimer;
    
    public NewPage()
    {
        dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Tick += dispatcherTimer_Tick;
        dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
        dispatcherTimer.Start();
    }
    
    public void dispatcherTimer_Tick(object sender, object e)
    {
        dispatcherTimer.Tick -= dispatcherTimer_Tick;
        dispatcherTimer.Stop();
        Frame.Navigate(typeof(MainPage));
    }
