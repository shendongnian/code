    using (var mySQLConnection = new SqlConnection(myConnectionString))
    {
       mySQLCommand = new SqlCommand("SELECT TOP 1 * FROM Table ORDER BY Id DESC", mySQLConnection, mySQLConnection);
       mySQLCommand.Connection.Open();
       using(mySQLDataReader = mySQLCommand.ExecuteReader())
       {
          while (mySQLDataReader.Read())
          {
            //Perform Logic : If the last record being returned meets some condition then call the below method
             MethodCalled();
          }            
       }
    }
