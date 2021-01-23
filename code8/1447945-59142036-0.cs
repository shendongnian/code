public void CreateDatabaseIfNotExists(string connectionString, string dbName)
{
	SqlCommand cmd = null;
	using (var connection = new SqlConnection(connectionString))
	{
		connection.Open();
		using (cmd = new SqlCommand($"If(db_id(N'{dbName}') IS NULL) CREATE DATABASE [{dbName}]", connection))
		{
			cmd.ExecuteNonQuery();
		}
	}
}
