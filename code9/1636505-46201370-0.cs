    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var mainViewModel = DataContext as MainViewModel;
        if (mainViewModel != null)
            mainViewModel.AddItem();
        var grid = MyGrid;
        var cell = new DataGridCellInfo(grid.Items[grid.Items.Count - 1], grid.Columns[0]);
        grid.CurrentCell = cell;
        Dispatcher.BeginInvoke(new Action(() =>
        {
            grid.BeginEdit();
        }), System.Windows.Threading.DispatcherPriority.Background);
    }
