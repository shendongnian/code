    // Start the clock when the program starts.
    private Stopwatch _pictureTimer = Stopwatch.StartNew();
    // Wait this long between pictures
    private readonly TimeSpan _pictureWaitTime = TimeSpan.FromMinutes(1.0);
    // Come here when key is pressed.
    if (_pictureTimer.Elapsed > _pictureWaitTime)
    {
        // take the screen shot
        // and then reset the stopwatch
        _pictureTimer.Restart();
    }
