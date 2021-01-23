    public UniformData(string sql) : this(sql, new List<SqlParameters>())
    {
    }
    public UniformData(string sql, List<SqlParameters> parameters)
    {
        con = new OracleConnection(connection);
        con.Open();
        com = new OracleCommand(sql, con);
        foreach (SqlParameters parameter in parameters)
        {
            com.Parameters.Add(parameter.ParamName, parameter.ParamValue);
        }
    }
