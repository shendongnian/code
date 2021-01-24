    public MainWindow()
    {
        InitializeComponent();
        _TG = new TaskGrid();
        _TD = new _1.TaskDetails();
        _TM = new _1.TaskMaster();
        myStack.Children.Add(_TG);
        _AUC = ActiveUserControl.Grid;
        _TG.Loaded += (s, e) =>
        {
            DataGrid dataGrid = GetChildOfType<DataGrid>(_TG);
            if (dataGrid != null)
            {
                foreach (var item in dataGrid.Items)
                {
                    DataGridRow dgr = dataGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (dgr != null)
                    {
                        DataGridCell cell = GetCell(dataGrid, dgr, 3); //<-- column index
                        if (cell != null)
                        {
                            Button button = GetChildOfType<Button>(cell);
                            if (button != null)
                            {
                                button.Click += new RoutedEvent(button_click);
                            }
                        }
                    }
                }
            }
        };
    }
