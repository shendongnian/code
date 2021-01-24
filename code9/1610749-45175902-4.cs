    private readonly MainViewModel _main = new MainViewModel();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = _main;
    }
