    public interface IConfiguration
    {
        string GetConnectionString();
    }
    
    public abstract class DbHandler
    {
        protected DbHandler(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString();
        }
    
        protected string ConnectionString { get; }
    }
    
    public class DbActivityRepository : DbHandler
    {
        public DbActivityRepository(IConfiguration configuration) 
            : base(configuration)
        {
        }
    
        private void DoSomething()
        {
            // use your connStr
            Console.Write(ConnectionString);
        }
    }
