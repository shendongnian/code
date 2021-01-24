    public class YourDbContext : DbContext
        {
            //yours DbSet<>
    
            protected override void OnModelCreating(ModelBuilder builder)
            {
                //yours EntityTypeConfiguration
            }
    
            /// <summary>
            /// Overridden for value object workaround
            /// </summary>
            /// <returns></returns>
            public override int SaveChanges()
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    foreach (var pi in entry.Entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
                    {
                        entry.Property(pi.Name).CurrentValue = pi.GetValue(entry.Entity);
                    }
                }
                return base.SaveChanges();
            }
        }
