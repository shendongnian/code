    public DataTable getData(string procedureName, SqlParameter[] procedureParams)
    {
        SqlCommand command = new SqlCommand(procedureName, connection);
        command.CommandType = CommandType.StoredProcedure;
            
        if (procedureParams != null)
        {
            for (int i = 0; i < procedureParams.Length; i++)
            {
                command.Parameters.Add(procedureParams[i]);
            }
        }
    
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable table = new DataTable();
        
        if (connection.State != ConnectionState.Open)        
            connection.Open();
        
        adapter.Fill(table);  
        connection.Close(); 
    
        return table;
    }
