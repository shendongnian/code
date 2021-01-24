    public async Task<IEnumerable<TResult>> GetAll<TEntry, TResult>()
    {
        return await filterListsDbContext.Set<TEntry>()
            .ProjectTo<TResult>()
            .ToListAsync();
    }
