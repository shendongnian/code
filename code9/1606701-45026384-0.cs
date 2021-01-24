     private void dtgTarafAvval_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dtgTarafAvval.SelectedCells.Count > 0)
            {
                CellValue = GetSelectedValue(dtgTarafAvval);
                //CellValue is a variable of type string.
              
            }
        }
        private string GetSelectedValue(DataGrid grid)
        {
            DataGridCellInfo cellInfo = grid.SelectedCells[0];
            if (cellInfo == null) return null;
            DataGridBoundColumn column = cellInfo.Column as DataGridBoundColumn;
            if (column == null) return null;
            FrameworkElement element = new FrameworkElement() { DataContext = cellInfo.Item };
            BindingOperations.SetBinding(element, TagProperty, column.Binding);
            return element.Tag.ToString();
        }
