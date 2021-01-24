    public class BruceDbContext:DbContext
    {
        public BruceDbContext()
            : base("Bruce_SQLConnectionString")
        {
        }
        public BruceDbContext(string connectionString) : base(connectionString)
        {
        }
    }
