    public class LogItemRepository : ILogItemRepository {
        private readonly IDbContext context = null;
    
        public LogItemRepository(IDbContext context) {
             this.context = context;
        }
        
        //...other code
    }
