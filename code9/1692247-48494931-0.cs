    MyViewModel _viewModel;
    public MyView()
    {
        InitializeComponent();
        _viewModel = new MyViewModel();
        DataContext = _viewModel;
    }
