    public async Task CallStoredProc1()
    {
        using(var conn = new Connection("yourConnectionString"))
        {
            using(var command = new SqlCommand("Procedure1", conn))
            {
                CommandType = CommandType.StoredProcedure;
                await conn.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }
    }
