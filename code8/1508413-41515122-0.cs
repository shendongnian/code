    abstract class AbstractDbContext : DbContext
    {
        protected AbstractDbContext(DbContextOptions options) : base(options)
        {
        }
    }
    class ConcreteDbContext : AbstractDbContext
    {
        public ConcreteDbContext(DbContextOptions<ConcreteDbContext> options) : base(options)
        {
        }
    }
