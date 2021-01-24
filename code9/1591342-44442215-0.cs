    public MainPage()
    {
        this.InitializeComponent();
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(3);
        int currentIndex = 0;
        timer.Tick += (s, e) =>
        {
            //this code will run every 3 seconds...
            if (Videos.Count > currentIndex)
            {
                Current = Videos[currentIndex++];
            }
        };
        timer.Start();
    }
