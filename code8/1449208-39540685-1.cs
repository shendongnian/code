    public class ApplicationDbContext : DbContext
    {
        public DbSet<SourceType> SourceTypes { get; set; }
        ...
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ...
            builder.SetSimpleUnderscoreTableNameConvention();
        }
    }
