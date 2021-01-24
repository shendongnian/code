    dataGridView1.RowsAdded += (sender, args) =>
    {
        if (d.Rows[args.RowIndex].Cells[0].Value != null)
        {
            d.Rows[args.RowIndex].ReadOnly = true;  //all row readonly
            d.Rows[args.RowIndex].Cells[0].ReadOnly = false; //except the first cell
        }
    };
    
    dataGridView1.CellEndEdit += (sender, args) =>
    {
        if (args.ColumnIndex == 0) //if edited cell its the first
        {
            d.Rows[args.RowIndex].ReadOnly = true; //all row readonly
            d.Rows[args.RowIndex].Cells[0].ReadOnly = false; //except the first cell
        }
    };
