    public void DeleteRow()
    {
        using (var connection = new SqlConnection("your connection string here..."))
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                // Next command is your query. 
                command.CommandText = "DELETE FROM Customers WHERE CustomerId = 1";
                command.CommandType = CommandType.Text;
                
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
