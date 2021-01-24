     public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ChangeTracker.DetectChanges();
    
        foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
        {
            //modify entry.Entity here
        }
    
        ChangeTracker.AutoDetectChangesEnabled = false;
        var result = base.SaveChanges(acceptAllChangesOnSuccess);
        ChangeTracker.AutoDetectChangesEnabled = true;
    
        return result;
    }
