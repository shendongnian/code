    public async Task<IEnumerable<Item>> GetAllFromDb()
    {
    	OracleConnection connection = null;
    	DbDataReader reader = null;
    	try
    	{
    		connection = new OracleConnection(connectionString);
    		var command = new OracleCommand(queryString, connection);
    		connection.Open();
		    reader = await command.ExecuteReaderAsync();
		    return this.BuildEnumerable(connection, reader);
	    }
    	catch (Exception)
	    {
            reader?.Dispose();
		    connection?.Dispose();    		
	    	throw;
    	}
    }
    private IEnumerable<Item> BuildEnumerable(OracleConnection connection, DbDataReader reader)
    {
    	using (connection)
    	using (reader)
    	{
    		while (reader.Read())
    		{
    			var item = new Item()
    			{
    				Prop = reader.GetString(0),
    			};
    			yield return item;
    		}
    	}
    }
