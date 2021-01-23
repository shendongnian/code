    public virtual void DetachAll()
    {
        foreach (var entityEntry in _context.ChangeTracker.Entries().ToArray())
        {
            if (entityEntry.Entity != null)
            {
                entityEntry.State = EntityState.Detached;
            }
        }
    }
