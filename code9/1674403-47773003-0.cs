    class MyDbContext : DbContext
    {
        ... // DbSets
        public async Task<MyResult> DoSomethingAsync(...)
        {
             object[] params = new Object[]
             {
                 new SqlParameter(@"ParamX", ...),
                 new SqlParameter(@"ParamY", ...);
             }
             const string SqlCommand = @"Exec MyStoredProcedure
                 @ParamX,
                 @ParamY);
             return await this.Database.ExecuteSqlCommandAsync(sqlCommand, params);
        }
