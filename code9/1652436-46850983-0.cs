    public class MyDataContext : DbContext, IMyDataContext
    {
        /*
        * the ohter stuff like IDbSet<T> etc.
        */
    
    
        public MyDataContext() : base("name=MyConnectionString")
        {
            Configure();
        }
    
        /// <summary>
        /// This constructor is for test usage only!
        /// </summary>
        /// <param name="connection">Test connection for in memory database</param>
        public MyDataContext(DbConnection connection) : base(connection, true)
        {
            Configure();
        }
    
    
        /// <summary>
        /// Configures the data context.
        /// </summary>
        private void Configure()
        {
            Configuration.LazyLoadingEnabled = false;
        }
    }
