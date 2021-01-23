    Timer myTimer = new Timer();
    myTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
    myTimer.Interval = 1000; // 1000 ms is one second
    myTimer.Start();
    public static void DisplayTimeEvent(object source, ElapsedEventArgs e)
    {
        // code here will run every second
    }
