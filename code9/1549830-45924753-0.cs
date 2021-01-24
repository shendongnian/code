    /*
     * Db Service
     */
    public interface IDbService
    {
        ISomeRepo SomeRepo { get; }
    }
    
    public class DbService : IDbService
    {
        readonly string connStr;
        ISomeRepo someRepo;
    
        public DbService(IConfiguration configuration)
        {
            this.connStr = configuration.GetConnectionString("key_for_connection_string");
        }
    
        public ISomeRepo SomeRepo
        {
            get
            {
                if (someRepo == null)
                {
                    someRepo = new SomeRepo(this.connStr);
                }
    
                return someRepo;
            }
        }
    }
