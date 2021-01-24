    using (SqlConnection mySQLConnection = new SqlConnection(myConnectionString))
    {
    using (SqlCommand mySQLCommand = new SqlCommand("SELECT TOP 1 * FROM Table ORDER BY Id DESC", mySQLConnection))
      {
        mySQLConnection.Open();
    
        SqlDataReader mySQLDataReader = mySQLCommand.ExecuteReader(CommandBehavior.CloseConnection);
         while (myReader.Read())
           {
              //Code logic here
            }
            // this call to myReader.Close(); will close the underlying connection
             myReader.Close();
        }
         MessageBox.Show("Connection state: " + mySQLConnection.State);
    }
