    MainWindowViewModel viewModel;
    public MainWindow()
    {
        viewModel = new MainWindowViewModel();
        DataContext = viewModel;
        InitializeComponent();
        viewModel.DataPlotModel = new PlotModel(); //<-- Set the view model property
    }
