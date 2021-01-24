    private void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DependencyObject dep = (DependencyObject)e.OriginalSource;
        DataGridCell cell = DataGridHelper.GetDataGridCell(dep);
        DataGridRow row = DataGridHelper.GetDataGridRow(dep);
        if (row != null)
        {
           if (row != lastRowSelected)
           {
               if (lastRowSelected != null)
               {
                   lastRowSelected.Background = colorOfLastRowSelected;
               }
               lastRowSelected = row;
               colorOfLastRowSelected = row.Background.Clone();
           }
           row.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6A5ACD"));
        }
    }
