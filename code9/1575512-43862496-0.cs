    public string LiveTime => DateTime.Now.ToString("dd MMM yyyy HH:mm:ss");
    public MainPage()
    {
        this.InitializeComponent();
        DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        timer.Tick += (s, e) => RaiseProperty(nameof(LiveTime));
        timer.Start();
    }
