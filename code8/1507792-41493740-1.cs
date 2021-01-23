    string queryString = "SELECT name, surname FROM employees";
    
    SqlCommand command = new SqlCommand(queryString, con);
    con.Open();
    SqlDataReader reader = command.ExecuteReader();
    try
    {
    	while (reader.Read())
    	{
    		Console.WriteLine(String.Format("{0}, {1}",
    	    reader["name"], reader["surname"]));
    	}
    }
    finally
    {
    	reader.Close();
    }
