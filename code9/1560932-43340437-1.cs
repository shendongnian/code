    try
    {
    	connection.Open();
    	MySqlCommand command = new MySqlCommand("SELECT * FROM User", connection);
    	using (MySqlDataReader reader = command.ExecuteReader())
    	{
    		while (reader.Read())
    		{
                // access your record colums by using reader
    			Console.WriteLine(reader["COLUMN_NAME"]);
    		}
    	}
    }
    catch (Exception ex)
    {
    	// handle exception here
    }
    finally
    {
    	connection.Close();
    }
