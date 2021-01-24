    public class MyFactory 
    {
        private readonly IMyDbContext dbContext;
    
        public MyFactory(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    
        public object Create()
        {
            // Use the dbContext, etc
        }
    }
