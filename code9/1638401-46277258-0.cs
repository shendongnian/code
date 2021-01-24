    public MainWindow()
    {
        InitializeComponent();
        Loaded += (s, e) => Title = $"{ActualHeight}"; // 39
        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1), IsEnabled = true };
        timer.Tick += (s, e) =>
        {
            stackPanel.Children.Add(new TextBlock { Text = "123", Width = 200, Height = 20 });
            Title = $"{ActualHeight}"; // 39, 59, 79 ... wrong
            // below is correct way, displays 59, 79 ...
            //Dispatcher.Invoke(() => Title = $"{ActualHeight}", DispatcherPriority.Render);
        };
    }
