    void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // Check that it is a valid row and it was in column #3 0 based indexing 
        if (!dataGridView1.CurrentCell.ColumnIndex.Equals(2) || e.RowIndex == -1) 
        {
            return;
        }
        // Check if the current cell is not null and that the value is not null 
        if (dataGridView1.CurrentCell == null || dataGridView1.CurrentCell.Value == null) 
        { 
            return; 
        }
        // ******EDIT******
        // Before I said to cast the DataGridViewCell Object
        // This is wrong, since the sender is the DataGrid itself not the cell object
        // Below the code is using the variable e to reference the events row index
        var theRow = dataGridView1?.Rows?[e.RowIndex];
        var theCell = theRow?.Cells?[2];
        var val = theCell?.Value?.ToString();
        if (string.IsNullOrEmpty(val))
        { 
            MessageBox.Show("The cell value is not assigned");
            return;
        }
 
        switch(val) 
        {
           case "http://www.mediafire.com/download/e4qd1r5r4170onj/Vert.rar":
               // Do something
               break;
           default:
               break;
        }
    }
