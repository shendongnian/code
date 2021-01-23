    public MainWindow()
    {
        InitializeComponent();
        var myTimer = new DispatcherTimer();
        myTimer.Tick += DisplayTimeEvent;
        myTimer.Interval = TimeSpan.FromSeconds(1);
        myTimer.Start();
    }
    public void DisplayTimeEvent(object source, EventArgs e)
    {
        DateTime now = DateTime.Now;
        DateTime today3am = now.Date.AddHours(3);
        if (DateTime.Today == today3am.Date && now >= today3am)
        {
            btnMyButton.IsEnabled = true;
        }
    }
