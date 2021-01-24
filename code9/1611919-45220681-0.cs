    OracleConnection conn = new OracleConnection("Your Connection string");
    conn.Open();
    DataSet dataSet = new DataSet();
    OracleCommand cmd = new OracleCommand(
        "SELECT * FROM TABLE1 t inner join TABLE2 t1 on t.code_value = t1.code_value"
    );
    cmd.CommandType = CommandType.Text;
    cmd.Connection = conn;
   
    using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
    {
      dataAdapter.SelectCommand = cmd;
      dataAdapter.Fill(dataSet);
    }
    DataTable dt = ds.Tables[0];
    //loop through table's rows/columns
    var a = dt.Rows["check_rule"].toString();
