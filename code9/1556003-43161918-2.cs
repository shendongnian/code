	public int GetLatestAccountID(string connectionString) 
	{
		using(var dbConn = new OleDbConnection(connectionString))
		{
			dbConn.Open();
	
			string query = "select Max(AccountID) as maxID from Account";
			using(var dbCommand = new OleDbCommand(query, dbConn))
			{
				var value = dbCommand.ExecuteScalar();
				if (value != DBNull.Value)
					return Convert.ToInt32(value) + 1;
	
				return 1;
			}
		}
	}
