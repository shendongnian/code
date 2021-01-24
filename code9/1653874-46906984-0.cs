    using (var sqlConnection = new SqlConnection("your_connectionstring"))
    {
        sqlConnection.Open();
        
    	using (var sqlCommand = sqlConnection.CreateCommand())
    	{
    		sqlCommand.CommandText = "select sum(field) from your_table";
    
    		object result = sqlCommand.ExecuteScalar();
    		
    		textBox1.Text = result == null ? "0" : result.ToString();
    	}
        sqlConnection.Close();
    }
