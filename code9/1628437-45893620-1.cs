        public virtual IQueryable<TEntity> GetAll()
        {
            if (_context==null)
            {
                throw new NotImplementedException("DB Not Found");
            }                 
            return _dbSet;
        } 
