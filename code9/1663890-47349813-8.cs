    private void GenerateIds()
    {
        foreach (DbEntityEntry addedEntry in this.ChangeTracker.Entries()
           .Where(entry => entry.State == EntityState.Added))
        {
            // every entry implements IPrimaryKey. Fill the Id           
            (IPrimaryKey)entry.Id = this.CreateId
        }
    }
    
    private GUID CreateId()
    {
        return Guid.NewGuid(); // or use your own Guid creator
    }
