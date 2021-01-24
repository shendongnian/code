    public async Task<MDTO> GetIeAsync(MDTO dtoItem)
    {
        ...
        connection.Open();
        Result.EnforceConstraints = false;
                
        SqlDataReader dataReader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        Result.Load(dataReader, LoadOption.OverwriteChanges, Tables);
        dtoItem.SR = Result;
        ...
    }
