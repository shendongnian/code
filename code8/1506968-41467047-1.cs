    public UniformData(string sql)
    {
        con = new OracleConnection(connection);
        con.Open();
        com = new OracleCommand(sql, con);
    }
    public UniformData(string sql, List<SqlParameters> myParams): this(sql)
    {
        foreach (SqlParameters Param in myParams)
        {
            com.Parameters.Add(Param.ParamName, Param.ParamValue);
        }
    }
