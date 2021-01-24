        static void Read()
    {
    try
    {
        string connectionString =
            "server=.;" +
            "initial catalog=employee;" +
            "user id=sa;" +
            "password=sa123";
        using (SqlConnection conn =
            new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd =
                new SqlCommand("SELECT * FROM EmployeeDetails", conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Id = ", reader["Id"]);
                        Console.WriteLine("Name = ", reader["Name"]);
                        Console.WriteLine("Address = ", reader["Address"]);
                    }
                }
                reader.Close();
            }
        }
    }
    catch (SqlException ex)
    {
        //Log exception
        //Display Error message
    }
    }
