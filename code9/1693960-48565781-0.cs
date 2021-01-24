    private async Task<IEnumerable<TEntity>> InvokeStoredProcedureAsync(string entityName)
    {
        var storedProcedureName = string.Format(CultureInfo.InvariantCulture, "sp_{0}BulkSelect", entityName);
        List<TEntity> temp;
        using (MyDbContext MyDbContext = new MyDbContext(_options))
        {
            MyDbContext.Database.OpenConnection();
            DbCommand cmd = MyDbContext.Database.GetDbConnection().CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedureName;
    
            using (var reader = cmd.ExecuteReader())
            {
               temp = (await reader.Cast<Task<IEnumerable<TEntity>>>()).ToList();
            }
        }
    
        return temp;
    }
