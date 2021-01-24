                table.Columns.Add("Username", typeof(string));
                table.Columns.Add("Status", typeof(string));
    
                table.Rows.Add("first", "second");
    
                dataGridView1.DataSource = table;
    
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
