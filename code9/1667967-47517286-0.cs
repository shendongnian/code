    DispatcherTimer dispatcherTimer;
    
    public void NewPage()
    {
        dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Tick += dispatcherTimer_Tick;
        dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
    }
    
    void dispatcherTimer_Tick(object sender, object e)
    {
        dispatcherTimer.Tick -= dispatcherTimer_Tick;
        Frame.Navigate(typeof(MainPage));
    }
