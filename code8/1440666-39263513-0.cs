     public void HighlightRows(IEnumerable<DataRow> rows, DataGrid grid)
        {           
            for (int index = 0; index < grid.Items.Count; index++)
            {
                DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                if (dgr.Item.GetType() == typeof(DataRowView))
                {
                    foreach (DataRow row in rows)
                    {
                        var array1 = row.ItemArray;
                        var array2 = (((DataRowView)dgr.Item).Row).ItemArray;
                        if (array1.SequenceEqual(array2))
                        {
                            dgr.Background = Brushes.LightBlue;
                        }                        
                    }
                }
            }
        }
