    private void MultisetGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex < 0)
                    return;
    
                if (e.ColumnIndex == 1)
                {
                    createdMap.RemoveAt(e.RowIndex);
                    DrawGrid.DataSource = null;
                    DrawGrid.DataSource = createdMap;
                }
    
            }
