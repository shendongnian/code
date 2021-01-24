    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
             Data Source=C:\Users\hp\Documents\KnowledgeBase.accdb;
             Persist Security Info=False;";
    using (var conn = new OleDbConnection(connectionString))
    {
        conn.Open();
        using (var command = conn.CreateCommand())
		{                
			command.CommandType = CommandType.Text;
			command.CommandText = "select Meaning from KnowledgeBase where Keyword = @Keyword";
			command.Parameters.AddWithValue("Keyword", cbo_SearchResult.Text);
            object result = command.ExecuteScalar();
            if (result != null)
            {
                lbl_Display.Text = result.ToString();
            }
		}
	}
