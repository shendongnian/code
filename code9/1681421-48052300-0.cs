    using (OracleConnection conn = new OracleConnection(cnn)){
    conn.Open();
    OracleCommand cmd = new OracleCommand();
    cmd.Connection = conn;
    cmd.CommandText = "PRC_ABCD_GETALL";
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("resultset_out", OracleType.Cursor, 
    ParameterDirection.Output);
    OracleDataReader rdr = cmd.ExecuteReader();              
    while (rdr.Read())
    {
        result.Add(Construct(rdr));
    }}
