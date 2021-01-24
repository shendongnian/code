    System.Timers.Timer _timer;
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        if (!connect())
        {
            //start a timer that calls connect() at regular intervals until it returns true.
            _timer = new System.Timers.Timer(TimeSpan.FromSeconds(1.5).TotalMilliseconds);
            _timer.Elapsed += Timer_Elapsed;
        }
    }
    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (connect())
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
