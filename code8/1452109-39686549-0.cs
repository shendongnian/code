    foreach(DataGridViewColumn column in dataGridView1.Columns)
    table.Columns.Add(column.Name, typeof(string));
    
    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++) {
        table.Rows.Add();
        for (int j = 0; j < dataGridView1.Columns.Count; j++) {
           table.Rows[i][j] = dataGridView1.SelectedRows[i].Cells[j].Value;
    
        }
    }
    rpt.SetDataSource(table);
