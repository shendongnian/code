    da.Fill(dt);
    dataGridView1.AutoGenerateColumns = false;
    DataGridViewColumn col = new DataGridViewColumn();
    col.Name = "name";
    col.HeaderText = "header";
    col.DataPropertyName = "yourDBField";
    
    dataGridView1.Columns.Add(col);
    dataGridView1.DataSource = dt;
    dataGridView1.AutoResizeColumn(DataGridViewAutoSizeColumnsMode.DisplayedCells);
