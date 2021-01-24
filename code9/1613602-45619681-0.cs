     public partial class DataBaseEntities : DbContext
        {
            public override int SaveChanges()
            {
                foreach (var entry in this.ChangeTracker.Entries<ModelName>().ToList())
                {
                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entry.Entity.EntryDateTimeStamp = DateTime.Now;
                    }
                    else if (entry.State == System.Data.Entity.EntityState.Modified)
                    {
                        entry.Entity.ModifiedDateTime = DateTime.Now;
    
                    }
    
                }
            }
        }
