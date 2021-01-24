            var sqlParameters = new List<SqlParameter>();
            var storedProcedureName = "SPName";
        
    //add parameters with value and type here
            sqlParameters.Add(new SqlParameter { SqlDbType = SqlDbType.Int, ParameterName = "@adyear", Value = adyear});
            sqlParameters.Add(new SqlParameter { SqlDbType = SqlDbType.Int, ParameterName = "@amonth", Value = amonth});
            sqlParameters.Add(new SqlParameter { SqlDbType = SqlDbType.Int, ParameterName = "@adys ", Value = adys });
        
    //execute store procedure here
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(storedProcedureName, connection) { CommandTimeout = 160, CommandType = commandType })
            using (var dataAdaptor = new SqlDataAdapter(command))
            {
                command.Parameters.AddRange(sqlParameters);
        
                connection.Open();
                dataAdaptor.Fill(dS);
            }
