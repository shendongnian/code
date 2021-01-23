    public async Task<T> GetAsync<T>(string storedProcedureName, SqlParameter[] sqlParameters = null) where T : class, new()
    {
        using (var conn = new SqlConnection(_connString))
        {
            var sqlCommand = await GetSqlCommandAsync(storedProcedureName, conn, sqlParameters);
            var dataReader = await sqlCommand.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            if (dataReader.HasRows)
            {
                var newObject = new T();
                if (await dataReader.ReadAsync())
                { dataReader.MapDataToObject(newObject); }
                return newObject;
            }
            else
            { return null; }
        }
    }
