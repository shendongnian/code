    public async Task<IEnumerable<TResult>> GetAll<TEntry, TResult>() where TEntry : class
    {
        return await filterListsDbContext.Set<TEntry>()
            .ProjectTo<TResult>()
            .ToListAsync();
    }
