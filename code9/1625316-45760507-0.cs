    _timer = new System.Timers.Timer(5);
    _timer.Elapsed += OnTimer;
    _timer.AutoReset = true;
    // _timer.Start();
    _timer.Enable = true;
  
    private static void OnTimer(object sender, System.Timers.ElapsedEventArgs args) { ProcessFiles(); }
