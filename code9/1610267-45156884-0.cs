	public List<T> ExecuteQuery<T>(string sqlQuery, object[] parameters = null) where T: class
	{
		try
		{
			var l = parameters !=null ? DbConnection.QueryAsync<T>(sqlQuery,parameters).Result : DbConnection.QueryAsync<T>(sqlQuery).Result;
            return l;
		}
		catch (Exception e)
		{ 
            throw;
            // or throw new MyCustomRepositoryException(e);
        }
	}
