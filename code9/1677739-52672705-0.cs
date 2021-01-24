    public async Task<bool> DeleteByIdAsync(TKey id, byte[] rowVersion = null, CancellationToken? token = null) 
    {
        var entityTracked = _context.ChangeTracker
            .Entries<TEntity>()
            .Select((EntityEntry e) => (TEntity)e.Entity)
            .SingleOrDefault(e => e.Id.Equals(id));                                                             
        if (entityTracked != null)                                                                         
        {
            _context.Remove(entityTracked);                                                                     // If entity is tracked just delete it
        }
        else                                                                                                    // If not tracked, just mock up a new entity.
        {
            var entityMocked = new TEntity { Id = id, RowVersion = rowVersion };                                // (*) ValidateModelContext extension custom code will not validate for EntityState.Deleted to avoid moked entity fail validations. We are going to delete it anyway so has no sense to validate it before deleting it.
                     
            if (rowVersion == null)                                                                             // DUDE!! Why you do not pass me a valid row version?. Then I forcelly must do a database trip to get the rowversion for this id. We do it executing an scalar function that returns me current row version value for this entity. 
                entityMocked.RowVersion = await GetRowVersionAsync(id.ToString()).ConfigureAwait(false);        // If the record do not exist on the database a null is returned. In such case, even if we already know that something went wrong, we let the dbconcurrency error occurs when saving changes since is really a concurency error, since the record not longer exists.
            _context.Remove(entityMocked);                                                                      // Just delete it it.
        }
        return true;
    }
