    public async Task<List<string>> GetUserNames()
    {
        EnsureConnectionOpen();
    
        using (var command = CreateCommand("GetUsernames", CommandType.storedProcedure))
        {
            using (var dataReader = await command.ExecuteReaderAsync())
            {
                var result = new List<string>();
    
                while (dataReader.Read())
                {
                    result.Add(dataReader["UserName"].ToString());
                }
    
                return result;
            }
        }
    }
