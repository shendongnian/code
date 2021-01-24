    private DispatcherTimer dispatcherTimer;
    
    public MainWindow()
    {
        InitializeComponent();
    
        //Create a timer with interval of 3 secs
        dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
        dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
    
        MyIcon.Visibility = System.Windows.Visibility.Visible;
    
        //Start the timer
        dispatcherTimer.Start(); 
    }
    
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        MyIcon.Visibility = System.Windows.Visibility.Collapsed;
    
        //Disable the timer
        dispatcherTimer.IsEnabled = false;
    }
