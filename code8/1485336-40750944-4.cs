    int retryCount = 0;
    while (retryCount < 10)
    {
       try
       {
          using (SqlCommand myCommand = new SqlCommand("MyStoredProc", new SqlConnection("Server=.;Database=MyDB;Trusted_Connection=True;")))
          {
             myCommand.Connection.Open();
             myCommand.CommandType = CommandType.StoredProcedure;
             myCommand.ExecuteNonQuery();
          }
       }
       catch (Exception ex)
       {
          retryCount++;
          System.Threading.Thread.Sleep(10000);
       }
    }
