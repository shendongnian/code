    public class CompanyContext : DbContext { 
        public DbSet<CompanyC> Companys { get; set; }
        public DbSet<Employee> Employees  { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Company>()
                .Include(s => s.CompanyEmployee)
                    .ThenInclude(e => e.Employee)
                    .AsNoTracking()
                .SingleOrDefaultAsync(m => m.CompanyID == id);
         }
      }
    }
