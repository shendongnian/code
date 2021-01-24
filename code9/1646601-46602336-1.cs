    public T ExecuteScalar<T>(string sql, CommandType commandType, params IDbDataParameter[] parameters)
    {
        return Execute<T>(sql, commandType, c =>
        {
            var returnValue = c.ExecuteScalar();
            return (returnValue != null && returnValue != DBNull.Value && returnValue is T)
             ? (T)returnValue
             : default(T);
        }, parameters);
    }
