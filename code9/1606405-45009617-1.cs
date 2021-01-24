    public MainWindow()
    {
        InitializeComponent();
        DataContext = myObj; //<--
        DispatcherTimer aTimer;
        aTimer = new DispatcherTimer();
        aTimer.Interval += TimeSpan.FromSeconds(1);
        aTimer.Tick += Timer_Tick;
        aTimer.Start();
    }
