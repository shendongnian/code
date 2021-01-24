    private async Task<IEnumerable<TEntity>> InvokeStoredProcedureAsync(string entityName)
    {
        var storedProcedureName = string.Format(CultureInfo.InvariantCulture, "sp_{0}BulkSelect", entityName);
        List<TEntity> temp = new List<TEntity>();
        using (MyDbContext MyDbContext = new MyDbContext(_options))
        {
            MyDbContext.Database.OpenConnection();
            DbCommand cmd = MyDbContext.Database.GetDbConnection().CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedureName;
    
            using (var reader = await cmd.ExecuteReaderAsync())
            {
               while (await reader.ReadAsync())
                   temp.Add(reader.Cast<TEntity>()); // ATTENTION: this does not work! (see below)
            }
        }
    
        return temp;
    }
