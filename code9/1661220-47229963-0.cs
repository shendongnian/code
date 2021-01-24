    class TrueAsyncReader : DbDataReader
    {
        ...
        public override async Task<bool> ReadAsync(CancellationToken cancellationToken) 
        {
            ...
            return await ReadFromDbAsync();
        }
    }
