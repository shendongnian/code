    private readonly Timer _timer;    
    private TimeSpan _timespan;
    private readonly TimeSpan _oneSecond;
    public Form1()
    {
        InitializeComponent();
        _timer = new Timer();
        _timer.Tick += timer1_Tick;
        _timer.Interval = 1000;
        _timer.Start();
        _timespan = TimeSpan.FromSeconds(20);
        _oneSecond = new TimeSpan(0, 0, 0, 1);
    }
    private void timer1_Tick(object sender, EventArgs eventArgs)
    {
        if (_timespan >= TimeSpan.Zero)
        {
            Time_label.Text = _timespan.ToString(@"m\:ss");
            _timespan = _timespan.Subtract(_oneSecond);
        }
        else
        {
            _timer.Stop();
        }
    }
