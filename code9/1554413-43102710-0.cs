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
                        cmd.Parameters.AddWithValue("@key", key);
                        cmd.Parameters.AddWithValue("@timestamp", ts);
                        cmd.Parameters.AddWithValue("@user", user);
                        return cmd.ExecuteNonQuery();
                   }
              }
        catch (Exception ex)
        {
              Console.WriteLine(ex.ToString());
              return -1;
        }
    }
