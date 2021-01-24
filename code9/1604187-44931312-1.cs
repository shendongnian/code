    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string query = "CREATE DATABASE " + databaseName;
        
        using(SqlCommand command = new SqlCommand(query, connection))
        {
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }               
    }
