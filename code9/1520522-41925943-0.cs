    MySqlDataAdapter a = new MySqlDataAdapter(query, conn)
    DataTable t = new DataTable();
    a.Fill(t);
    // Create a seperate bindingsource object your can control
    var bindingSource = new BindingSource();
    bindingSource.DataSource = t;
    // Assign that bindingsource object to the dgv
    dataGridView1.DataSource = bindingSource;
    // Now sort on a column
    bindingSource.Sort = "copy number";
