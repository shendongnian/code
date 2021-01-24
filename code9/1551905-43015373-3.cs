    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
    }
