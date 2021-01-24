    public MainWindow()
    {
        InitializeComponent();
        var data = GetListAsync();
        dataGrid.ItemsSource = data.Result;
    }
