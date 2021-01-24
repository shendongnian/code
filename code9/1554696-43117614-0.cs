    public partial class MyAppDbContext : DbContext
    {
        public override int SaveChanges()
        {
             ChangeTracker.Entries().ToList().ForEach(entry =>
            {
  
                // entry, here, is DbEntityEntry.
                // it will allow you to see original and new values,
                // such as entry.OriginalValues
                // and entry.CurrentValues
                // You can also find its type
                // entry.Entity.GetType()
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Added:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        break;
                }
            });
    
           // call the base.SaveChanges();
           base.SaveChanges();    
        }
    
    }
