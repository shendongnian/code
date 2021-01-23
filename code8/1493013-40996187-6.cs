    public async Task CreateAsync(IQueryable<T> source, int page, int pageSize)
    {
        TotalCount = await source.CountAsync(); // async here would help
        PageCount = GetPageCount(pageSize, TotalCount);
        Page = page < 1 ? 0 : page - 1;
        PageSize = pageSize;
        AddRange(await source.Skip(Page * PageSize)
                             .Take(PageSize)
                             .ToListAsync()); // async here too!
    }
