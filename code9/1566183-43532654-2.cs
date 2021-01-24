    public class CompanyContext : DbContext { 
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees  { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CompanyId);
            }
        }
    }
