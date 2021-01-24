    public MainWindow()
    {
        InitializeComponent();
        System.Windows.Threading.DispatcherTimer myTimer = new System.Windows.Threading.DispatcherTimer();
        myTimer.Interval = TimeSpan.FromSeconds(1);
        myTimer.Start();
        myTimer.Tick += timeToCall;
    }
    private void timeToCall(object sender, EventArgs e)
    {
        DrivesCheck();
    }
