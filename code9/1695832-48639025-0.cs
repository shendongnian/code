    using (SqlConnection conn = new SqlConnection(cnnString))
    {
      connection.Open();
      foreach (Variable v in dto)
      {
             SqlCommand command = new SqlCommand(XXXXXXXXXX, connection);
             // Setting command timeout to 10 seconds
             command.CommandTimeout = 10;
             command.ExecuteNonQuery();
      } 
    }
