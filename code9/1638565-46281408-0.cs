    public async Task<TEntity> SingleOrDefaultAsyncEager(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Entities.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return await query.SingleOrDefaultAsync(filter);
        }
