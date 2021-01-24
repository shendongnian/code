     public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer<ApplicationDbContext>("Server = (localdb)\\mssqllocaldb; Database = MyDatabaseName; Trusted_Connection = True; MultipleActiveResultSets = true");
    
                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }
