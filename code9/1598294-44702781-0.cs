    private void DataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (DataGrid.Columns[e.ColumnIndex].Name == "colReserved")
        {
            DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)DataGrid.Rows[e.RowIndex].Cells["colReserved"];
            if ((Boolean)checkCell.Value)
            {
                //Checked
                MessageBox.Show("Checked");
            }
            else
            {
                //Not Checked
                MessageBox.Show("UnChecked");
            }
            DataGrid.Invalidate();
        }
    }
    private void DataGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (DataGrid.IsCurrentCellDirty)
        {
            DataGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
