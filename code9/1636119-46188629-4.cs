    List<string> penalties = new List<string>();
    string joinedPenalty = String.Join(",", penalties);
    string query = "SELECT * FROM tblpenalty WHERE Area IN (" + joinedPenalty + ");";
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
    }
