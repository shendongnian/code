    public class BruceDbContext : DbContext
    {
        public BruceDbContext()
            : base("name=brucedbcontext")
        {
        }
        public BruceDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
        //...
    }
