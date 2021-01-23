    // Get all the checked items in a list of strings...
    List<string> values = checkedListBox1.CheckedItems.Cast<string>().ToList();
    List<MySqlParameter> prms = new List<MySqlParameter>();
    List<string> prmsNames = new List<string>();
    // Loop over the values and build the parameter names and the parameters
    for (int x = 0; x < values.Count; x++)
    {
        // The parameter with a conventional name
        prms.Add(new MySqlParameter("@" + x.ToString(), MySqlDbType.VarChar) { Value = values[x] });
        // the parameter' names
        prmsNames.Add("@" + x.ToString());
    }
    // The command text
    string query = @"select * from tblcenters 
                     where centerName in (" + 
                    string.Join(",", prmsNames) + ")";
    using (MySqlConnection conn = new MySqlConnection(connectionString))
    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
    {
        // Add the parameters collection to the select command....
        adapter.SelectCommand.Parameters.AddRange(prms.ToArray());
        DataTable ds = new DataTable();
        adapter.Fill(ds);
        dataGridView1.DataSource = ds;
    }
