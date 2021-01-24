    public partFourWindow()
    {
        InitializeComponent();
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        this.ResizeMode = ResizeMode.NoResize;
        this.Loaded += OnLoaded;
    }
    private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
    {
         testing.Text = this.workOrderText;
    }
