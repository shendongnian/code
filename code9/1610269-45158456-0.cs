	public List<T> ExecuteQuery<T>(string sqlQuery, object[] parameters = null) where T : class
	{
		if (parameters != null)
		{
			return DbConnection.Query<T>(sqlQuery, parameters)
		}
		else
		{
			return DbConnection.Query<T>(sqlQuery);
		}
	}
