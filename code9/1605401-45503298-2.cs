    public static DataGridRow GetDataGridRow(DependencyObject dep)
    {
        while ((dep != null) && !(dep is DataGridCell) && !(dep is DataGridColumnHeader))
        {
           dep = VisualTreeHelper.GetParent(dep);
        }
        if (dep is DataGridColumnHeader)
        {
           DataGridColumnHeader columnHeader = dep as DataGridColumnHeader;
        }
        DataGridRow row = null;
        if (dep is DataGridCell)
        {
           DataGridCell cell = dep as DataGridCell;
           // navigate further up the tree
           while ((dep != null) && !(dep is DataGridRow))
           {
               dep = VisualTreeHelper.GetParent(dep);
           }
           row = dep as DataGridRow;
        }
        return row;
    }
