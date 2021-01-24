    private void itemsInSheet_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var column = e.Column as DataGridBoundColumn;
                if (column != null)
                {                    
                    var bindingPath = (column.Binding as Binding).Path.Path;
                    if (bindingPath == "Quantity")
                    {                       
                        int rowIndex = e.Row.GetIndex();
                        var el = e.EditingElement as TextBox;
                        m_engine.UpdateTotalPrice(rowIndex);
                        itemsInSheet.Focus();
                        itemsInSheet.CurrentCell = new DataGridCellInfo(itemsInSheet.Items[rowIndex], itemsInSheet.Columns[0]);
                        itemsInSheet.BeginEdit();                  
                    }
                }
            }
        }
