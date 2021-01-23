    public MainWindow()
    {
        InitializeComponent();
    
        MainWindowViewModel vm = new MainWindowViewModel();
    
        DataContext = vm;
    
        vm.LoadData();
    }
