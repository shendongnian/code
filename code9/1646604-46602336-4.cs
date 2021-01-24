    T Execute<T>(string sql, CommandType commandType, Func<IDbCommand, T> function, params IDbDataParameter[] parameters)
    {
        using (var con = new TConnection()) // replace TConnection with your connection object
        {
            con.ConnectionString = _ConnectionString;
            using (var cmd = new NpgsqlCommand()) 
            {
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.CommandType = commandType;
                if (parameters.Length > 0)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                con.Open();
                return function(cmd);
            }
        }
    }
