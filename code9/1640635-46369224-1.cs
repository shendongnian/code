    public MainPage() {
        this.InitializeComponent();
        this.Loaded += async (sender, e) => {
            try {
                InitGPIO();
                await InitSpi();
    
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(500);
                timer.Tick += Timer_Tick;
            } catch (Exception) {
    
            }
        };
    }
