    public override int SaveChanges() 
    {
      var addedEntites= ChangeTracker.Entries<IfYouWantSpecifyAnyType>()
                             .Where(p => p.State == EntityState.Added)
                             .Select(p => p.Entity);
    
      var modified= ChangeTracker.Entries<IfYouWantSpecifyAnyType>()
                             .Where(p => p.State == EntityState.Modified)
                             .Select(p => p.Entity);
    
      var now = DateTime.UtcNow;
    
      foreach (var added in addedEntites) 
      {
        added.CreatedAt = now;
        added.LastModifiedAt = now;
      }
    
      foreach (var modified in modified) 
      {
        modified.LastModifiedAt = now;
      }
    
      return base.SaveChanges();
    }
