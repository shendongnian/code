    public class CompanyContext : DbContext { 
        public DbSet<CompanyC> Companys { get; set; }
        public DbSet<Employee> Employees  { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Company>()
                .HasMany(e => e.Employee)
                 .Map(t => t.MapLeftKey("CompanyID ");
         }
      }
    }
