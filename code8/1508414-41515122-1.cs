    abstract class AbstractDbContext<TContext> : DbContext
        where TContext : AbstractDbContext<TContext>
    {
        protected AbstractDbContext(DbContextOptions<TContext> options) : base(options)
        {
        }
    }
    class ConcreteDbContext : AbstractDbContext<ConcreteDbContext>
    {
        public ConcreteDbContext(DbContextOptions<ConcreteDbContext> options) : base(options)
        {
        }
    }
