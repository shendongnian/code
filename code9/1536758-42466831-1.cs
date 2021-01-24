    private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) 
    {
        DataGrid datagrid = sender as DataGrid;
        if (e.EditAction == DataGridEditAction.Commit)
        {
            if (e.Column is DataGridBoundColumn)
            {
                DataGridBoundColumn column = (DataGridBoundColumn)e.Column;
                if (column.Header.ToString() == "Size")
                {
                    string oldValue = e.Row.DataContext.GetType().GetProperty("Size")
                                       .GetValue(e.Row.DataContext).ToString();
                    TextBox element = e.EditingElement as TextBox;
                    string newValue = element.Text;
                    int oldSize = int.Parse(oldValue);
                    int newSize = int.Parse(newValue);
                    if (newSize < oldSize)
                    {
                        string strMsg = "New size, " + newValue + ", is smaller then the original size, "
                                      + oldValue + ".\nDue to potential data loss, this is not allowed.";
                        MessageBox.Show(strMsg);
                        element.Text = oldValue;
                        e.Cancel = true;
                    }
                }
            }
        }
    }
