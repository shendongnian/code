    System.Timers.Timer T;
    public Form1()
    {
        InitializeComponent();
        T = new System.Timers.Timer();
        T.SynchronizingObject = this;
        T.Interval = 5000; //Miliseconds;
        T.Elapsed += new ElapsedEventHandler(TimerElapsed);
        T.Start();
    }
