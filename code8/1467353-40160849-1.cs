    public MainWindow()
    {
        InitializeComponent();
        var viewModel = new CameraViewModel();
        viewModel.StartCamera();
        DataContext = viewModel;
    }
