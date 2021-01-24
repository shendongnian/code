    public class WestCoreDbContext : DbContext
    {
        public WestCoreDbContext(DbContextOptions<WestCoreDbContext> options) : base(options)
        {
    
        }
    
        public virtual DbSet<SoftwareTestCase> SoftwareTestCases { get; set; }
        //Define further DbSets
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SoftwareTestCaseConfiguration());
            //Apply further configurations
    
            modelBuilder.MyOracleNamingConventions();
    
            base.OnModelCreating(modelBuilder);
        }
    
        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);
        }
    }
    
    //This configuration class is separated from the WestCoreDbContext and can go into a separate code file
    internal class SoftwareTestCaseConfiguration : IEntityTypeConfiguration<SoftwareTestCase>
    {
        public void Configure(EntityTypeBuilder<SoftwareTestCase> modelBuilder)
        {
            modelBuilder.Entity<SoftwareTestCase>().HasOne(x => x.SoftwareTest).WithMany(op => op.SoftwareTestCases).IsRequired().HasForeignKey(@"StId");
            modelBuilder.Entity<SoftwareTestCase>().HasMany(x => x.SoftwareTestCaseSteps).WithOne(op => op.SoftwareTestCase).IsRequired().HasForeignKey("StcId");
        }
    }
