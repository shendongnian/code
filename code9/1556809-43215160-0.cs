    const string connectionString = "";
    SqlConnection connection = new SqlConnection(connectionString)
    public DataTable ExecuteCommandToDataTable(string commandText, CommandType 
    commandType, int timeout, params SqlParameter[] parameters)
    {
	    if (this.connection == null)
            throw new NullReferenceException("The connection was not initialized.");
	    SqlCommand command = new SqlCommand(commandText, 
        this.connection.SqlConnection);            
	    command.CommandType = commandType;
	    command.CommandTimeout = timeout;
	    for (int i = 0; parameters != null && i < parameters.Length; i++)
		    command.Parameters.Add(parameters[i]);
	
	    this.connection.Open();
	
	    DataTable tbl = new DataTable();
	    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
	    {
		    adapter.Fill(tbl);
	    }
	
	    this.connection.Close();
	    return tbl;
    }
