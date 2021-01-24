    public Form1()
    {
        InitializeComponent();
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Interval = 1000;
        timer.AutoReset = true;
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
    }
