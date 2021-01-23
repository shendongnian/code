    public interface IDbContextFactory
    {
        ApplicationContext Create();
    }
    public class DbContextFactory() : IDbContextFactory, IDisposable
    {
        private ApplicationContext context;
        private bool disposing;
        public DbContextFactory()
        {
        }
        public ApplicationContext Create() 
        {
            if(this.context==null) 
            {
                // Get this value from some configuration
                string providerType = ...;
                // and the connection string for the database
                string connectionString = ...;
                var dbContextBuilder = new DbContextOptionsBuilder();
                if(providerType == "MSSQL") 
                {
                    dbContextBuilder.UseSqlServer(connectionString);
                }
                else if(providerType == "Sqlite")
                {
                    dbContextBuilder.UseSqlite(connectionString);
                }
                else 
                {
                    throw new InvalidOperationException("Invalid providerType");
                }
                this.context = new ApplicationContext(dbContextBuilder);
            }
            return this.context;
        }
        
        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing){
            if (disposing){
                disposing?.Dispose();
            }
        }
    }
