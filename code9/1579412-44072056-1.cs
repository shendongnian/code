    public async Task<TestObject> GetAsync(int id)
    {
        using(var connection = new SqlConnection(_connectionString)
        {
            // using Dapper
            return await connection.QuerySingleAsync<TestObject>("sp_GetTestObject", new {Id = id}, commandType = CommandType.StoredProcedure);
        }
    }
