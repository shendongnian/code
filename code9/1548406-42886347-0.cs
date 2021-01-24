	public int rowCount(string tableName)
	{
		string ssQL = string.Format("SELECT count(*) from {0}", tableName);
		int rowCount;
		using (var connection = THF.Models.SQLConnectionManager.GetConnection())
		{
			using (var command = new SqlCommand(sSQL, connection))
			{
				connection.Open();
				command.CommandTimeout = 0;
				rowCount = command.ExecuteScalar();
				connection.Close();
			}
		}
		return rowCount;
	}
