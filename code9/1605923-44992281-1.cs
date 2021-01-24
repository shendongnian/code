    string name = "Jacob's Ladder";
    string commandText = "SELECT Name, LicenseType, till FROM myTable WHERE Name = @Name";
     
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand findItForMe = new SqlCommand(commandText, connection);
        // Use AddWithValue to assign name
        // The parameterized query will escape your strings and keep you safe from hackers.
        command.Parameters.AddWithValue("@name", name);
        try
        {
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                // do something here
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
