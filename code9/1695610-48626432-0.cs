    var query = "SELECT TOP 1 [Id] FROM User WHERE Username = @Username";
    using(var connection = new OleDbConnection(path))
    using(var command = new OleDbCommand(query, connection))
    {
         connection.Open();
         command.Parameters("Username", txtUsername.Text());
         using(var reader = command.ExecuteReader())
              while(reader.Read())
              {
                   // Do something.
              }
    }
