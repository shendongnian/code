    DependencyObject dep = (DependencyObject)e.OriginalSource;
    int index = -1;
    while ((dep != null) && !(dep is DataGridCell) && !(dep is DataGridColumnHeader))
    {
        dep = VisualTreeHelper.GetParent(dep);
    }
    if (dep is DataGridColumnHeader)
    {
        DataGridColumnHeader header = dep as DataGridColumnHeader;
        index = header.DisplayIndex;
        dgfinal_Copy.Columns[index].Visibility = Visibility.Collapsed;
    }
    
    if (dep is DataGridCell)
    {
        DataGridCell call = dep as DataGridCell;
        index = dgfinal_Copy.CurrentCell.Column.DisplayIndex;
        dgfinal_Copy.Columns[index].Visibility = Visibility.Collapsed;
    }
