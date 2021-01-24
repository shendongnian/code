    foreach( var entry in _dbContext.ChangeTracker.Entries() )
    {
        if( entry.Entity != entity )
        {
            entry.State = EntityState.Unchanged;
        }
    }
