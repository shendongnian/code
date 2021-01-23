    public partial class MyDbContext : DbContext
    {
        public override int SaveChanges()
        {
            try
            {
                var changeSet = ChangeTracker.Entries<Child>();
    
                if (changeSet != null)
                {
                    foreach (var entry in changeSet.Where(c => c.State == EntityState.Added || c.State == EntityState.Modified))
                    {
                        // Update here the parent
                    }
                }
    
                return base.SaveChanges();
            }
            catch (Exception exception)
            {
                
            }
        }
    }
