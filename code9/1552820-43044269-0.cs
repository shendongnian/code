    public class TemporaryDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        private readonly DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        public TemporaryDbContextFactory(DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder)
        {
            if(optionsBuilder==null)
                throw new ArgumentNullException(nameof(optionsBuilder));
            this.optionsBuilder = optionsBuiler;
        }
        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            return new ApplicationDbContext(builder.Options);
        }
    }
