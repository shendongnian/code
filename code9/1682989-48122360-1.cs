    public async Task<List<Auto>> GetAllAutosSortedByNameAsync(AutoCriteria criteria)
    {
        return await GetFullyGraphedAutos()
            .Where(x => string.IsNullOrEmpty(criteria.Name))
            .OrderBy(x => x.Id)
            .ToListAsync();
    }
