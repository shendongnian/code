    private static async Task GetData(Func<SqlConnection, SqlCommand> commandBuilder,
        Action<IDataRecord> dataFunc)
    {
        using (var connection = new SqlConnection())
        {
            await connection.OpenAsync();
            using (var command = commandBuilder(connection))
            {
                command.CommandTimeout = 0;
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        dataFunc(reader);
                    }
                }
            }
        }
    }
    // OR
    private static async Task<IEnumerable<T>> GetData<T>(Func<SqlConnection, SqlCommand> commandBuilder,
        Func<IDataRecord, T> dataFunc)
    {
        using (var connection = new SqlConnection())
        {
            await connection.OpenAsync();
            using (var command = commandBuilder(connection))
            {
                command.CommandTimeout = 0;
                using (var reader = await command.ExecuteReaderAsync())
                {
                    // linked list to avoid allocation of an array
                    var result = new LinkedList<T>();
                    while (await reader.ReadAsync())
                    {
                        result.AddLast(dataFunc(reader));
                    }
                    return result;
                }
            }
        }
    }
