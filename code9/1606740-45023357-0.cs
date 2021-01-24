    public class DbContext : IDbContext {
        private readonly IMongoDatabase database = null;
    
        public DbContext(IMongoDatabase database) 
            this.database = database;
        }
    
        public IMongoCollection<LogItem> LogItemsCollection {
            get {
                return database.GetCollection<LogItem>("LogItem");
            }
        }
    }
