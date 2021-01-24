    public class MyDbContext : DbContext
    {      
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<StateEnum>(e => {...});
        }
    }
