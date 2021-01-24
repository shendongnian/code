    private void dataGridView1_CellMouseMove(object sender, 
                                             DataGridViewCellMouseEventArgs e)
    {
        dataGridView1.SelectionMode = e.ColumnIndex == yourImageColumIndex ?
                      DataGridViewSelectionMode.RowHeaderSelect : 
                      DataGridViewSelectionMode.FullRowSelect;    // or whatever you want
    }
