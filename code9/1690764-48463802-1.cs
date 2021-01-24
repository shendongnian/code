    public async Task<IEnumerable<TResult>> GetAll<TEntry, TResult>()
    {
        return await filterListsDbContext.Set<TEntry>()
            .AsNoTracking()
            .ProjectTo<TResult>()
            .ToArrayAsync();
    }
