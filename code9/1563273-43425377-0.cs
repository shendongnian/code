        var sqlParameters = new List<SqlParameter>();
        var storedProcedureName = "SPName";
    
        sqlParameters.Add(new SqlParameter { SqlDbType = SqlDbType.Int, ParameterName = "@stdate", Value = stdate });
    .
    .
    .
    
        using (var connection = new SqlConnection(ConnectionString))
        using (var command = new SqlCommand(storedProcedureName, connection) { CommandTimeout = 160, CommandType = commandType })
        using (var dataAdaptor = new SqlDataAdapter(command))
        {
            command.Parameters.AddRange(sqlParameters);
    
            connection.Open();
            dataAdaptor.Fill(dS);
        }
