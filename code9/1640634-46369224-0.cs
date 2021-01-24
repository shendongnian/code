    public MainPage() {
        this.InitializeComponent();
        this.Loaded += OnPageLoaded;
    }
    private async void OnPageLoaded(object sender, EventArgs e) {
        try {
            InitGPIO();
            await InitSpi();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
        } catch (Exception) {
        }
    }
