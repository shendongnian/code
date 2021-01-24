        public TEntity GetByIdLoadFull(string id, List<string> navigatonProoperties)
        {
            if (id.isNullOrEmpty())
            {
                return null;
            }
            IQueryable<TEntity> query = dbSet;
            if (navigationProperties != null)
            {
                foreach (var navigationProperty in navigationProperties)
                {
                    query = query.Include(navigationProperty.Name);
                }
            }
            
            return query.SingleOrDefault(x => x.Id == id);
        }
