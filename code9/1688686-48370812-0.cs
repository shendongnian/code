     using (MySqlConnection mConnection = new MySqlConnection(connectionString))
     {
         mConnection.ConnectionTimeout = 60;
         mConnection.Open();
         using (MySqlCommand myCmd = new MySqlCommand("XXX"))
         {
             myCmd.CommandTimeout = 60;
             myCmd.CommandType = CommandType.Text;
             // DO STUFF HERE
         }
     }
