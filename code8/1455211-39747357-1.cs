    public MainWindow()
    {
        InitializeComponent();
        var viewModel = new ViewModel();
        viewModel.Codes.Add(new Codes { CodeID = "1", Code = "CODETEXT" });
        DataContext = viewModel;
    }
