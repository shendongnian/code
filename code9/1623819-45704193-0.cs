     SELECT c.Id
        , c.Name
        , a.Id As AddressId
        , a.Street As AddressStreet
     FROM Customer c
         INNER JOIN Address a ON a.CustomerId = c.Id
    var query = "SELECT ...";
    using (var connection = new SqlConnection())
    using (var command = new SqlCommand(query, connection))
    {
        var customers = new List<Customer>();
        connection.Open();
        using (var reader = command.ExecuteReader())
        {
            while(reader.Read())
            {
                var customer = new Customer
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    PrimaryAddress = new Address
                    {
                        Id = reader.GetInt32(2),
                        Street = reader.GetString(3)
                    }
                };
                customers.Add(customer);
            }
        }
    }
