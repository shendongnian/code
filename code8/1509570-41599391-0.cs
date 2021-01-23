    public OdbcDataReader ExecuteQuery(string sql)
    {
        var cmd = new OdbcCommand(sql.Replace("'", ""), connection);
        return cmd.ExecuteReader();
    }
