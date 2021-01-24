    public class MyDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
    
        public MyDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
