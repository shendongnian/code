    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        DataContext = vm;
        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
        timer.Tick += (s, e) => vm.Update();
        timer.Start();
    }
