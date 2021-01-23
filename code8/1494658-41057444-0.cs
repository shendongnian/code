	static string cs = @"server=localhost;user id=bar;password=foobar;database=foo;";
	DataTable results = new DataTable("Results");
	using (MySqlConnection connection = new MySqlConnection(cs))
	{
		using (MySqlCommand command = new MySqlCommand(queryString, connection))
		{
			command.Connection.Open(); //throws System.TypeInitializationException
			command.ExecuteNonQuery();
			using (MySqlDataReader reader = command.ExecuteReader())
			results.Load(reader);
		}
	}
