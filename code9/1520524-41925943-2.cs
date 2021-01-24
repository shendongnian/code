    // your original starter code
    MySqlDataAdapter a = new MySqlDataAdapter(query, conn)
    DataTable t = new DataTable();
    a.Fill(t);
    // Create a seperate bindingsource object you can control
    var bindingSource = new BindingSource();
    bindingSource.DataSource = t;
    // Now sort on a column
    bindingSource.Filter = "[copy number] >= 1 AND [copy number] <= 100";
    // Assign that bindingsource object to the dgv
    dataGridView1.DataSource = bindingSource;
