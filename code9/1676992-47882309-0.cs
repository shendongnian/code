    public async Task<DataSet> ExecDataSetProcAsync(string qry, params object[] args)
    {
    	var ds = new DataSet();
    	var builder = new SqlConnectionStringBuilder(DBConnection.GetConnectionString())
    	{
    		AsynchronousProcessing = true
    	};
    	using (var conn = new SqlConnection(builder.ConnectionString))
    	{
    		await conn.OpenAsync();
    		using (var cmd = CreateCommand(qry, CommandType.StoredProcedure, args))
    		{
    			cmd.Connection = conn;
    			using(var reader = await cmd.ExecuteReaderAsync())
    			{
    				if (await reader.ReadAsync())
                    {
    					while (await reader.ReadAsync())
    					{
    						ds.Tables.Add().Load(reader);
    					}
    				}
    			}
    		}
    	}
    	return ds;	
    }
