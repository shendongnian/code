    // Here, you do the actuall reading from the dataReader in the populate function
    public bool ExecuteReader(string sql, CommandType commandType, Func<IDataReader, bool> populate, params IDbDataParameter[] parameters)
    {
        return Execute<bool>(sql, commandType, c => populate(c.ExecuteReader()), parameters);
    }
