    DispatcherTimer dispatcherTimer;
    
    public NewPage()
    {
        dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Tick += dispatcherTimer_Tick;
        dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
        dispatcherTimer.Start();
        CheckIdle();
    }
    
    public void dispatcherTimer_Tick(object sender, object e)
    {
        dispatcherTimer.Tick -= dispatcherTimer_Tick;
        dispatcherTimer.Stop();
        Frame.Navigate(typeof(MainPage));
    }
    private void CheckIdle()
    {
        //Calling DispatcherTimer.Start() will reset the timer interval
        Window.Current.CoreWindow.PointerMoved += (s, e) => dispatcherTimer.Start();
        Window.Current.CoreWindow.PointerPressed += (s, e) => dispatcherTimer.Start();
        Window.Current.CoreWindow.PointerReleased += (s, e) => dispatcherTimer.Start();
        Window.Current.CoreWindow.PointerWheelChanged += (s, e) => dispatcherTimer.Start();
        Window.Current.CoreWindow.KeyDown += (s, e) => dispatcherTimer.Start();
        Window.Current.CoreWindow.KeyUp += (s, e) => dispatcherTimer.Start();
        Window.Current.CoreWindow.CharacterReceived += (s, e) => dispatcherTimer.Start();
    }
