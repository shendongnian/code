	public List<T> ExecuteQuery<T>(string sqlQuery, object[] parameters = null) where T : class
	{
		using (var dbc = new DbConnection())
		{
			if (parameters != null)
			{
				return dbc.Query<T>(sqlQuery, parameters).ToList();
			}
			else
			{
				return dbc.Query<T>(sqlQuery).ToList();
			}
		}
	}
