    // connectionString is the connection string for the ServerA..DB1
    using (var conn = new SqlConnection(connectionString))
    {
         conn.Open();
         // provide commandText as the SQL query having the full name of Server2..DB2
         using (var command = new SqlCommand(commandText, conn))
         {
             using (var reader = command.ExecuteReader())
             {
                  while(reader.Read())
                  {
                      // read the result
                  }
             }
         }
    }
