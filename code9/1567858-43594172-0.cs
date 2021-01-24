    using UWPHelper.Utilities;
    
    ThreadPoolTimer timer = new ThreadPoolTimer(TimeSpan.FromSeconds(1));
    timer.Tick += (sender, e) =>
    {
        // Invoked every second
    }
    timer.Start();
    timer.Stop();
