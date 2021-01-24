    public override DataTable ExecuteQuery(string query)
    {
        SqlConnection connection = new SqlConnection(ConnectionString);
    
    	StringBuilder readOnlyQuery = new StringBuilder();
        readOnlyQuery .AppendLine("execute as user = 'user_reader';");      
        readOnlyQuery .AppendLine(query);
        query = readOnlyQuery .ToString();
    
        SqlCommand command = new SqlCommand(query, connection);
    
        ...Execute the command
    }
