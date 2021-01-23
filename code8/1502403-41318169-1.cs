    private void AlterRow(DataGridRowEventArgs e)
    {
        var cell = GetCell(dataGrid, e.Row, 0);
        if (cell == null) return;
    
        var item = e.Row.Item as Ro;
        if (item == null) return;
    
        cell.Background = item.c1Color;
    
        cell = GetCell(dataGrid, e.Row, 1);
        if (cell == null) return;
    
        cell.Background = item.c2Color;
    }
    
    public static T GetVisualChild<T>(Visual parent) where T : Visual
    {
        T child = default(T);
        int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < numVisuals; i++)
        {
            var v = (Visual)VisualTreeHelper.GetChild(parent, i);
            child = v as T ?? GetVisualChild<T>(v);
            if (child != null)
            {
                break;
            }
        }
        return child;
    }
    
    
    public static DataGridCell GetCell(DataGrid host, DataGridRow row, int columnIndex)
    {
        if (row == null) return null;
    
        var presenter = GetVisualChild<DataGridCellsPresenter>(row);
        if (presenter == null) return null;
    
        // try to get the cell but it may possibly be virtualized
        var cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
        if (cell == null)
        {
            // now try to bring into view and retreive the cell
            host.ScrollIntoView(row, host.Columns[columnIndex]);
            cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
        }
        return cell;
    }
 
