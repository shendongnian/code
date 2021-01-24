    using UWPHelper.Utilities;
    
    // TimeSpan indicates the interval of the timer
    ThreadPoolTimer timer = new ThreadPoolTimer(TimeSpan.FromSeconds(1));
    timer.Tick += OnTick;
    
    void OnTick(object sender, EventArgs e)
    {
        // Method invoked on Tick - every second in this scenario
    } 
    // To start the timer
    timer.Start();
    // To stop the timer
    timer.Stop();
