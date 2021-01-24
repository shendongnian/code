    public DataSet FillDataSet(string sql, CommandType commandType, params IDbDataParameter[] parameters)
    {
        return Execute<DataSet>(sql, commandType, c => FillDataSet(c), parameters);
    }
    private DataSet FillDataSet(IDbCommand command)
    {
        var dataSet = new DataSet();
        using (var adapter = new TAdapter())
        {
            adapter.SelectCommand = command;
            adapter.Fill(dataSet);
        }
        return dataSet;
    }
