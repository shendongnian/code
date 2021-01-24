    public MainWindow()
    {
        InitializeComponent();
        var viewModel = new ViewModel();
        DataContext = viewModel;
        viewModel.LoadImage(
            @"D:\Games\steamapps\common\RailWorks\Content\Routes\00000036-0000-0000-0000-000000002012\MainContent.ap",
            "RouteInformation/image.png");
    }
