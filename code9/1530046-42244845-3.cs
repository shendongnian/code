    DataGridViewComboBoxColumn c = new DataGridViewComboBoxColumn();
    c.Name = "ComboColumn";
    c.DataSource = dataTable;
    c.ValueMember = "ID";
    c.DisplayMember = "Item";
    dataGridView1.Columns.Add(c);
