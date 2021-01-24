    var allItems = new List<MyClass>();
    using (var connection = New SqlConnection(connectionString))
    using (var command = New SqlCommand(query, connection))
    {
        connection.Open();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var item = new MyClass
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Birthdate = reader.GetDatetime(2)
                };
                allItems.Add(item);
            }
        }
    }
    return allItems;
