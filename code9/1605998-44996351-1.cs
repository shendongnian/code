    public MainWindow()
    {
        InitializeComponent();
        PsVm = new ProggressbarViewModel();
        DataContext = PsVm;
    }
