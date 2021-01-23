    var dt = LoadData();
    dataGridView1.DataSource = dt;
    //Add new column to DataGridView
    var newColumn = new DataGridViewTextBoxColumn();
    newColumn.HeaderText = "NewColumn";
    newColumn.Name = "NewColumn";
    dataGridView1.Columns.Add(newColumn);
    //Copy Values
    foreach (DataGridViewRow r in this.dataGridView1.Rows)
    {
        if(!r.IsNewRow)
            r.Cells["NewColumn"].Value = Decrypt(r.Cells["ExistingColumn"].Value);
    }
