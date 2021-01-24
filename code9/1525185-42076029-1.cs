    public void GetCustomer()
    {
        using (var connection = new SqlConnection("your connection string here..."))
        {
            using (var command = new SqlCommand())
            {
                SqlDataReader reader;
                command.Connection = connection;
                // Next command is your query. 
                command.CommandText = "SELECT * FROM Customers WHERE CustomerId = 1";
                command.CommandType = CommandType.Text;
                
                connection.Open();
                reader = cmd.ExecuteReader();
                // Data is accessible through the DataReader object here.                 
            }
        }
    }
