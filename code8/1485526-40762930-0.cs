    using (OracleConnection connection = new OracleConnection())
    {
    connection.ConnectionString = connectionString;
    connection.Open();
    OracleCommand command = connection.CreateCommand();
    string sql = _query;
    command.CommandText = sql;
    OracleDataAdapter oAdapter = new OracleDataAdapter(sql, connection);
    oAdapter.Fill(myDataSet);
    connection.Close();
    return myDataSet;}
