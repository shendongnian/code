    DbConnection = connection = _context.Database.GetDbConnection();
    using(DbCommand cmd = connection.CreateCommand()) {
        cmd.CommandText = "select dbo.FunctionReturnVarchar(@id)";    
 
        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = id });
        if (connection.State.Equals(ConnectionState.Closed)) { connection.Open(); }
        var value = (string) await cmd.ExecuteScalarAsync();
    }
    if (connection.State.Equals(ConnectionState.Open)) { connection.Close(); }
