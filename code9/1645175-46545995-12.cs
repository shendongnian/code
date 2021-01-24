    public MainWindow()
    {
        InitializeComponent();
        var vm = new MainViewModel();
        vm.BuildData();
        DataContext = vm;
    }
