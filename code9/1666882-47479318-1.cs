        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            SqlCommand command = new SqlCommand(
                queryString, connection);
            connection.Open();
        }
