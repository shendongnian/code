    private ViewModel viewModel = new ViewModel();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = viewModel;
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        ...
        await viewModel.LoadImagesAsync(..., "*.jpg"));
    }
