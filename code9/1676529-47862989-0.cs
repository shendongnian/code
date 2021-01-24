        public virtual void Delete(TEntity entity)
        {
            DbContext.Configuration.ValidateOnSaveEnabled = false;
            DbContext.ChangeTracker.DetectChanges();
            var entry = DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }
