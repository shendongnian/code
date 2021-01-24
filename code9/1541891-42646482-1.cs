    dataGridView.Columns.Add( "column1Column", "T1" );
    dataGridView.Columns[0].ReadOnly = true;
    //The first column (T1) is now ReadOnly
    dataGridView.Columns.Add("column2Column", "T2");
    dataGridView.Columns.Add("column3Column", "T3");
    dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    //Or use this if you want to copy cell content of readonly cells
    dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
