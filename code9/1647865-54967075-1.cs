	private void Query()
	{
		using (SqlConnection connection = new SqlConnection(_connectionString))
		{
			connection.Execute("WAITFOR DELAY '00:00:02';");
		}
	}
	private async Task QueryAsync()
	{
		using (SqlConnection connection = new SqlConnection(_connectionString))
		{
			await connection.ExecuteAsync("WAITFOR DELAY '00:00:02';");
		}
	}
