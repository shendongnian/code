    var penalties = new List<string>();
    var parameters = new string[penalties.Count];
    var cmd = new SqlCommand();
    for (int i = 0; i < penalties.Count; i++)
    {
    	parameters[i] = $"@Age{i}";
    	cmd.Parameters.AddWithValue(parameters[i], penalties[i]);
    }
    string query = $"SELECT * FROM tblpenalty WHERE Area IN ({string.Join(", ", parameters)});";
    using (connection)
    {
    	using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
    	{
    		DataSet ds = new DataSet();
    		adapter.Fill(ds);
    		dataGridView1.DataSource = ds.Tables[0];
    		dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
    	}
    }
