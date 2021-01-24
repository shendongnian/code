    using (SqlConnection mySQLConnection = new SqlConnection(myConnectionString))
    {
    using (SqlCommand mySQLCommand = new SqlCommand("SELECT TOP 1 * FROM Table ORDER BY Id DESC", mySQLConnection))
      {
        mySQLConnection.Open();
    
        SqlDataReader mySQLDataReader = mySQLCommand.ExecuteReader(CommandBehavior.CloseConnection);
         while (mySQLDataReader.Read())
           {
              //Code logic here
            }
            // this call to mySQLDataReader.Close(); will close the underlying connection
             mySQLDataReader.Close();
        }
         MessageBox.Show("Connection state: " + mySQLConnection.State);
    }
