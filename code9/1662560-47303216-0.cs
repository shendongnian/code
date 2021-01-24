    class MyDbContext : DbContext
    {
        public DbSet<...> Table1 {get; set;}
        public DbSet<...> Table2 {get; set;}
        #region stored procedures
        public void Components(int orderTypeId, string orderTypeKey, ...
             KeyValuePair<string, string> pair, ...)
        {
            // TODO: fill code
        }
    }
