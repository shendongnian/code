	public int GetLatestAccountID(string connectionString) 
	{
		using(var dbConn = new OleDbConnection(connectionString))
		{
			dbConn.Open();
	
			string query = "select Max(AccountID) from Account";
			using(var dbCommand = new OleDbCommand(query, dbConn))
			{
				var value = dbCommand.ExecuteScalar();
				if ((value != null) && (value != DBNull.Value))
					return Convert.ToInt32(value) + 1;
	
				return 1;
			}
		}
	}
