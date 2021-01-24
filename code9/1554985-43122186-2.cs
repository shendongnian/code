    public class MyFactory : IFactory
    {  
        public object Create(object someProperty)
        {
            // build object
        }
    }
    public class MyService
    {
        private readonly IMyDbContext dbContext;
        private readonly IFactory factory;
    
        public MyService(IMyDbContext dbContext, IFactory factory)
        {
            this.dbContext = dbContext;
            this.factory = factory;
        }
    
        public void DoWork()
        {
            var property = dbContext.Get(something);
            var newObj = factory.Create(property);
            // Use stuff
        }
    }
