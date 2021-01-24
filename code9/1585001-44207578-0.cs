    public class FilteredDbContext 
    {
        private readonly MainDbContext dbContext;
        public FilteredDbContext(MainDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        
        public IQueryable<Record> Records 
        {
            get { return dbContext.Records.Where(...); }
        }
    }
 
