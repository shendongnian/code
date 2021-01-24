            private void Grid_Selected(object sender, RoutedEventArgs e)
            {
                if (e.OriginalSource.GetType() == typeof(DataGridCell))
                {
                    DataGridCell cell = (e.OriginalSource as DataGridCell);
                    if (cell.IsReadOnly == true)
                        return;
                    // Starts the Edit on the row;
                    DataGrid grd = (DataGrid)sender;
                    grd.BeginEdit(e);
                    cell.IsEditing = true;
                    string cellValue = GetSelectedCellValue();
                }
            }
    
            public string GetSelectedCellValue()
            {
    
                DataGridCellInfo cells = Grid.SelectedCells[0];
  
                string columnName = cells.Column.SortMemberPath;
    
                if (item == null || columnName == null) return null;
    
                object result = item.GetType().GetProperty(columnName).GetValue(item, null);
    
                if (result == null) return null;
    
                return result.ToString();
            }
