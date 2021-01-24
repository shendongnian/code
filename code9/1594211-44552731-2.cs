	public static bool AccountValidation(string username, string password)
	{
		const string statement = "select dbo.AccountValidation(@username, @password)";
		string result = null;
		
		// reference assembly System.Configuration
		string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["YourDb"].ConnectionString;
		using(var connection = new SqlConnection(connStr))
		using(SqlCommand cmd = new SqlCommand(statement, connect))
		{
			cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 200){Value = username});
			cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 200){Value = password});
			connect.Open();
			using(SqlDataReader reader = cmd.ExecuteReader())
			{
				if(reader.Read())
					result = reader.GetString(0); // read back the first column of the first row
			}
		}
		if (result != "true")
		{
			return false;
		}
		else
		{
			return true;
		}
	}
