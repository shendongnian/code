    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        vm.Patterns.Add(new SnakePattern
        {
            Name = "Pattern 1",
            Image = new BitmapImage(new Uri("pack://application:,,,/Pics/snakepattern1.jpg"))
        });
        ...
        vm.SelectedPattern = vm.Patterns[0];
        DataContext = vm;
    }
