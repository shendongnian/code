	public string GetTableContentsAsJson(string serverName, string databaseName, string userName, string password, string tableName)
	{
		System.Data.SqlClient.SqlConnectionStringBuilder builder =  new System.Data.SqlClient.SqlConnectionStringBuilder();
		builder["Data Source"] = serverName;
		builder["integrated Security"] = false;
		builder["Initial Catalog"] = databaseName;
		builder["User ID"] = userName;
		builder["Password"] = password;
		Console.WriteLine(builder.ConnectionString);
		
		using (var connection = new SqlConnection(builder.ConnectionString))
		{
			connection.Open();
			var images = connection.Query($"SELECT * FROM {tableName}");
			string s = JsonConvert.SerializeObject(images);
			return s;
		}
	}
