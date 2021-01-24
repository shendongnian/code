    public MainWindow()
    {
        InitializeComponent();
        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
        timer.Tick += ShowBallon;
        timer.Start();
    }
    private void ShowBallon(object sender, EventArgs e)
    {
        ((DispatcherTimer)sender).Stop();
        string title = "WPF NotifyIcon";
        string text = "This is a standard balloon";
        new TaskbarIcon().ShowBalloonTip(title, text, BalloonIcon.None);
    }
