	public string BuildMessageBody()
	{
		// Create a message template that will 
		string template = @"Process is completed successfully.
				       1) Sum of Salary is {0}
				       2) Sum of Bonus is {1}
				       3) Count of distinct Accounts is {2}";
		string query = @"SELECT SUM(T.[Salary]) AS TotalSalary, Sum(T.[Bonus]) AS TotalBonus, COUNT(DISTINCT T.AccountNumber) AS UniqueAccounts FROM table AS T";
		string totalSalary = string.Empty;
		string totalBonus = string.Empty;
		string uniqueAccounts = string.Empty;
		string body = string.Empty;
		using(OleDbConnection dbConnection = new OleDbConnection("xxx"))
		{
			dbConnection.Open();
			using (OleDbCommand cmd = new OleDbCommand(query, dbConnection))
			{
				cmd.CommandType = System.Data.CommandType.Text;
				using (OleDbDataReader  reader = cmd.ExecuteReader())
				{
					// This should only ever yield one row due to aggregation in source query
					// But this implementation will result in the last row (arbitrary source sorting)
					// being preserved
					while (reader.Read())
					{
						// Access by ordinal position
						totalSalary = reader[0].ToString();
						totalBonus = reader[1].ToString();
						uniqueAccounts = reader[2].ToString();
					}
				}
			}
			// At this point, we should have results
			body = string.Format(template, totalSalary, totalBonus, uniqueAccounts);
		}
		return body;
	}
