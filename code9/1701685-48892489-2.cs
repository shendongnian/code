    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        DataContext = vm;
        Loaded += async (s, e) =>
            await vm.LoadImagesAsync(Directory.EnumerateFiles("...", "*.jpg"));
    }
