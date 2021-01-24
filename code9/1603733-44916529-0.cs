    DataSet dataSet = new DataSet();
    using (OracleConnection connection = new OracleConnection(connectionstring))
    {
      using (OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(new OracleCommand(query, connection)))
      {
        oracleDataAdapter.Fill(dataSet, table);
      }
    }
    return dataSet;
