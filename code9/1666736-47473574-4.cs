    public override int SaveChanges(bool acceptAllChangesOnSuccess)
            {
                ChangeTracker.DetectChanges();
    
                foreach (var entry in ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added ||
                         e.State == EntityState.Modified))
                {
                    //modify entry.Entity here
                    foreach (var prop in entry.Properties)
                    {
                        if ((entry.State == EntityState.Added ||
                    prop.IsModified) && prop.OriginalValue is string)
                            prop.CurrentValue = prop.CurrentValue + "edited";
                    }
                }
    
                ChangeTracker.AutoDetectChangesEnabled = false;
                var result = base.SaveChanges(acceptAllChangesOnSuccess);
                ChangeTracker.AutoDetectChangesEnabled = true;
    
                return result;
            }
