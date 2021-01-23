    DependencyObject mainDep = new DependencyObject();
    private void DataGrid_Click(object sender, RoutedEventArgs e)
    {
        DependencyObject dep = (DependencyObject)e.OriginalSource;
        while ((dep != null) && !(dep is DataGridCell) && !(dep is DataGridColumnHeader))
        {
            dep = VisualTreeHelper.GetParent(dep);
        }
        mainDep = dep;
    }
    private void menuItem_Click(object sender, RoutedEventArgs e)
    {
        DependencyObject dep = mainDep;
        int index = -1;
        if (dep is DataGridColumnHeader)
        {
            DataGridColumnHeader header = dep as DataGridColumnHeader;
            index = header.DisplayIndex;
            dtgrdNotes.Columns[index].Visibility = Visibility.Collapsed;
        }
        if (dep is DataGridCell)
        {
            DataGridCell cell = dep as DataGridCell;
            index = cell.Column.DisplayIndex;
            dtgrdNotes.Columns[index].Visibility = Visibility.Collapsed;
        }
        label.Content = index;
    }
