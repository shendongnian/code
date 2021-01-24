    private async Task<IEnumerable<TEntity>> InvokeStoredProcedureAsync(string entityName)
    {
        var storedProcedureName = string.Format(CultureInfo.InvariantCulture, "sp_{0}BulkSelect", entityName);
        using (var db = new MyDbContext(_options))
        {
            var result = await db.Set<TEntity>().FromSql(storedProcedureName).ToListAsync();
            return result;
        }
    }
