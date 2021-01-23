    OracleCommand cmd = new OracleCommand("return_num", Oraclecon);
    cmd.Parameters.Add(new OracleParameter("xNum", OracleDbType.Decimal,
        ParameterDirection.Output));
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.ExecuteNonQuery();
    OracleDecimal d = (OracleDecimal)cmd.Parameters[0].Value;
    double result = d.ToDouble();
