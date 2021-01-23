    private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if(e.ColumnIndex<0 || e.RowIndex<0)
            return;
        var columnB = grid.Columns[e.ColumnIndex];
        if (columnB.Name != "B")
            return;
        var value = grid.Rows[e.RowIndex].Cells["A"].Value;
        if (value == null || value == DBNull.Value)
            return;
        //Usually its enough to set cell.Value = Decrypt(value.ToString());
        //But since you may have performance issues by Decrypt
        //I check if the cell doesn't have value, will set the value for cell
        var cell = grid.Rows[e.RowIndex].Cells["B"];
        if (cell.Value== null || cell.Value == DBNull.Value)
        {
            cell.Value = Decrypt(value.ToString());
        }
    }
