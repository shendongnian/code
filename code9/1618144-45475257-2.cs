    string queryString = "SELECT UserID, LogDate, WorkCode from DeviceLogs_" + Month(DateTime.Now()) + "_" + Year(DateTime.Now());
    string connectionString = "Server=.\PDATA_SQLEXPRESS;Database=;User Id=sa;Password=2BeChanged!;";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}, {2}",
                reader["UserId"],reader["LogDate"]), reader["WorkCode"]));// etc
            }
        }
        finally
        {
            // Always call Close when done reading.
            reader.Close();
        }
    }
