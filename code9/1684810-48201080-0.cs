    var query = @"SELECT t0.ACT_TYPE, t0.ST_DT,t0.AC_ST_DT  FROM ACTIVITY  t0 WHERE (t0.AC_ST_DT > :p0 OR t0.ST_DT > :p1) AND t0.ACT_TYPE = :p2";
    OracleConnection connection = new OracleConnection(cs);
    try
    {              
        connection.Open();
        OracleCommand cmd = new OracleCommand(query, connection);
        OracleDataAdapter oda = new OracleDataAdapter(cmd);
        OracleParameter pp = new OracleParameter();
        DateTime date = new DateTime(2016, 01, 01);
        OracleParameter dp1 = new OracleParameter();
        dp1.OracleDbType = OracleDbType.Date;
        dp1.ParameterName = "p0";
        dp1.Value = date;
        cmd.Parameters.Add(dp1);
        OracleParameter dp2 = new OracleParameter();
        dp2.OracleDbType = OracleDbType.Date;
        dp2.ParameterName = "p1";
        dp2.Value = date;
        cmd.Parameters.Add(dp2);
        var sp = new OracleParameter();
        sp.OracleDbType = OracleDbType.Varchar2;
        sp.ParameterName = "p2";
        sp.Value = "SC";
        cmd.Parameters.Add(sp);
        var dt = new DataTable();
        oda.Fill(dt);
        cmd.Dispose();
    }
    finally
    {
        connection.Close();
    }
