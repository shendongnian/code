    public void OpenConnection()
    {
      if (connection == null)
      {
         connection = new OracleConnection(this.connectionString);
         connection.Open();
         return;
      }
      switch (connection.State)
      {
         case ConnectionState.Closed:
         case ConnectionState.Broken:
           connection.Close();
           connection.Dispose();
           connection = new OracleConnection(this.connectionString);
           connection.Open();
           return;
      }
    }
