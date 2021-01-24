    OracleConnection conn = new OracleConnection("Your Connection string");
    
    Conn.Open;
    
    DataSet dataSet = new DataSet();
    
    OracleCommand cmd = new OracleCommand("your select query");
    
    cmd.CommandType = CommandType.Text;
    
    cmd.Connection = conn;
    
    using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
    
    {
    
      dataAdapter.SelectCommand = cmd;
      dataAdapter.Fill(dataSet);
    }
