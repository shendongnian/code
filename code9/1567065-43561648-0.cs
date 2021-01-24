    public class RentalsDBContext : DbContext {
    
        public RentalsDBContext() : base() { }
    
        public RentalsDBContext(DbContextOptions<RentalsDBContext> options) : base(options)
        {
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
        }
    
        //...other code removed for brevity
    }
