    public async Task<T> GetAsync<T>(int id, params Expression<Func<T, object>>[] includes)
        where T: class, IEntity
    {
        var query = context.Set<T>().AsQueryable();
        if (includes.Length > 0)
        {
            query = includes.Aggregate(query,
              (current, include) => current.Include(include));
        }
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }
