    public interface IDbContextFactory
    {
        ApplicationContext Create();
    }
    public class DbContextFactory() : IDbContextFactory, IDisposable
    {
        private MyTenantContext context;
        private bool disposing;
        public DbContextFactory(/* other dependencies here */)
        {
        }
        public MyTenantContext Create(string tenantId) 
        {
            if(this.context==null) 
            {
                // and the connection string and replace the database name in it
                // with the tenantId or whatever means you have to determine
                // which database to access
                string connectionString = ...;
                var dbContextBuilder = new DbContextOptionsBuilder();
                dbContextBuilder.UseSqlServer(connectionString);
                this.context = new MyTenantContext(dbContextBuilder);
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
