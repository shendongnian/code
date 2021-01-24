    public bool ISContextChanges()
 {
    return this.ChangeTracker.Entries().Any(a => a.State == EntityState.Added
                                              || a.State == EntityState.Modified
                                              || a.State == EntityState.Deleted);
