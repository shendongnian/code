	void SampleMethod(string name, string lastName, string database)
	{
		using(var connection = new SqlConnection(MY_CONNECTION_STRING))
		{
			connection.Execute(MY_STORED_PROCEDURE, new { 
				name = name,
				lastName = lastName,
				database = database}, commandType: System.Data.CommandType.StoredProcedure);
		}
	}
