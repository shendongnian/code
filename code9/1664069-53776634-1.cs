    using (connection)
	using (SqlCommand command = new SqlCommand(
	  "SELECT ManagerUsername from tblManagers WHERE ManagerUsername = @ManagerUsername and ManagerEmail = @ManagerEmail",
	  connection))
	{
		connection.Open();
		using (SqlDataReader reader = command.ExecuteReader())
		{
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
						reader.GetString(1));
				}
			}
			else
			{
				Console.WriteLine("No rows found.");
			}
			
		} 
    }
