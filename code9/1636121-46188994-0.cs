    string query = "SELECT * FROM tblpenalty WHERE Area IN ({0})";
    string[] penaltiesArray = penalties.ToArray(); // list converted to array as in /a/6804883/
    string[] parameters = penalties.Select((x, n) => "@area" + n.ToString()).ToArray();
    query = string.Format(query, string.Join(",", parameters));
    using (connection)
    {
        using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
        {
            // iterate through the list & set parameters to data adapter
            for (int i = 0; i < parameters.Length; i++)
            {
                // use MySqlDataParameter.SelectCommand directly without additional MySqlCommand
                // and use MySqlDbType depending on data type used in target column
                adapter.SelectCommand.Parameters.Add(parameters[i], MySqlDbType.VarChar).Value = penaltiesArray[i];
            }
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
