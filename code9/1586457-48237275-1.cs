    public class MyDbContext : DbContext
    {      
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<Foo>().Property(x => x.State).HasDefaultValue(StateEnum.Ok);
        }
    }
