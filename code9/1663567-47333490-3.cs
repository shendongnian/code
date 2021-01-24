      SqlConnection connection = ....
      SqlCommand command = new SqlCommand(connection);
      connection.Open();
      for(int i = 0 ; i < passedIDsfromBrowser.Length; i++){
         command.CommandText = "YOURQUERY";
         command.ExecuteNonQuery();
      }
      connection.Close();
