    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Table.Update(entity);
        foreach( var entry in _dbContext.ChangeTracker.Entries() )
        {
            if( entry.Entity != entity )
            {
                entry.State = EntityState.Unchanged;
            }
        }
        
        await _dbContext.SaveChangesAsync();
        return entity;
    }
