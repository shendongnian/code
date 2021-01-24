     using (MySqlConnection mConnection = new MySqlConnection(connectionString))
     {
         using (MySqlCommand myCmd = mConnection.CreateCommand())
         {
             mConnection.Open();
             myCmd.CommandTimeout = 60;
             myCmd.CommandType = CommandType.Text;
             myCmd.CommandText = "XXX";
             using (var reader = cmd.ExecuteReader())
             {
                 while (reader.Read())
                 {
                     // DO STUFF HERE
                 }
             }
         }
     }
