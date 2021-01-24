    public bool MyStoredProcedureExists()
    {
         return this.StoredProcedureExists(myStoredProcedureName);
    }
    public bool StoredProcedureExists(string procedureName)
    {
        object[] functionParameters = new object[]
        {
            new SqlParameter(@"procedurename", procedureName),
        };
        string query = @"select [name] from sys.procedures where name= @procedurename";
        return this.Database.SqlQuery<string>(query, functionParameters)
            .ToList()
            .Where(item => item == procedureName)
            .Any();        
    }
