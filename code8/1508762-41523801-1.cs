    public void Update(TEntity updated, Tkey key)
            {
                updated.ObjectState = ObjectState.Modified;
    
                var existing = _dbSet.Find(key);
                if (existing == null) return;
    
                existing.ObjectState = ObjectState.Modified;
                dbContext.Entry(existing).CurrentValues.SetValues(updated);
                dbContext.Set<TEntity>().Attach(existing);
                
                
            }
       
