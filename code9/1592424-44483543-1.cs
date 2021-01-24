    List<OracleConnections> Connections = new List<OracleConnections>();
    DataTable FinalResults = new DataTable();
    
    foreach (var Connection in Connections)
    {
       using (Connection)
       {
          DataTable TemporaryTable = new DataTable();
          Connection.Open();
          OracleCommand Command = new OracleCommand("SomeCommandText", Connection);
          OracleDataAdapter Adapter = new OracleDataAdapter(Command);
          Adapter.Fill(TemporaryTable);
          FinalResults.Merge(TemporaryTable);
       }
    }
