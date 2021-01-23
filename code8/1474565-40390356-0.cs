    using (SqlConnection connection = new SqlConnection(
                   connectionstring1)) // You won't need a second connection string if both are the same
        {
            SqlCommand command = new SqlCommand(query2, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
