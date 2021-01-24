    private void extractValue()
    {
      if (connection.State != ConnectionState.Open)
       { 
         this.connection.Open();
       }
       String query = "UPDATE dLogger SET device=device*2";
       OdbcCommand command = new OdbcCommand(query, this.connection);
       command.Execute();
    }
