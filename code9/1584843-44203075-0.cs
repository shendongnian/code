    public MainWindow()
    {
        InitializeComponent();
        var viewModel = new ViewModel();
        var rows = viewModel.Rows;
        int numberOfColumns = rows[0].Length; //assume all string[] have the same length
        DataContext = new VM1();
        for (int i = 0; i < numberOfColumns; ++i)
        {
            dataGrid1.Columns.Add(new DataGridTextColumn() { Binding = new Binding("[" + i + "]"), Header = i.ToString() });
        }
        dataGrid1.ItemsSource = rows;
    }
