    int id = 0;
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
    
        using(var command = new SqlCommand("Select Max(MemberId) from Medleminfo", connection))
        {
        
            id = (int)command.ExecuteScalar();
        }
    }
