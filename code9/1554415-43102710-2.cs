    public int UpdatetData(int key, System.DateTime ts, string user)
    {
         // Build parameterized query (with escaped DateTime)
         var sql = @"UPDATE parameters 
                        SET [DateTime] = @timestamp,
                            User = @user
                      WHERE Key = @key";
         try
         {
              using(var connection = new MySqlConnection("{your-connection-string}"))
              {
                   connection.Open();
                   using (var command = new MySqlCommand(sql, connection))
                   {
                       
                        command.Parameters.AddWithValue("@key", key);
                        command.Parameters.AddWithValue("@timestamp", ts);
                        command.Parameters.AddWithValue("@user", user);
                        return command.ExecuteNonQuery();
                   }
              }
        }
        catch (Exception ex)
        {
              Console.WriteLine(ex.ToString());
              return -1;
        }
    }
