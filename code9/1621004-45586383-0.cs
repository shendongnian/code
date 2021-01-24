    class LinqQueries
    {
        // default constructor: use the default DbContext
        public LinqQueries()
        {
            this.DbContext = new p4_databaseEntities();
        }
        // special constructor: user provided dbContext
        public LinqQueries(p4_databaseEntities dbContext)
        {
            this.dbContext = dbContext;
        }
        private readonly p4_databaseEntities dbContext;
        public IEnumerable<...> GetMyElements(...)
        {
             return this.dbContext....;
        }
    }
