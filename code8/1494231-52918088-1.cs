    public async Task<T> GetAsync<T>(string storedProcedureName, SqlParameter[] sqlParameters)
    {
        using (var conn = new SqlConnection(_connString))
        {
            T newObject = default;
            var dataReader = await ExecuteReaderAsync(conn, CommandType.StoredProcedure, storedProcedureName, sqlParameters);
            if (await dataReader.ReadAsync())
            {
                dataReader.MapDataToObject(newObject);
            }
            return newObject;
        }
    }
