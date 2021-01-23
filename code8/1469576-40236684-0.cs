    public class InheritanceMappingContext : DbContext
    {
        public DbSet<BillingDetail> BillingDetails { get; set; }
    
          
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Users");
            });
        }
    }
