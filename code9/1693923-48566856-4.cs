    public MainWindow()
    {
        InitializeComponent();
        var data = new List<ExampleItemViewModel>();
        data.Add(new ExampleItemViewModel { Number = 1 });
        data.Add(new ExampleItemViewModel { Number = 2 });
        grid1.DataContext = data;
    }
