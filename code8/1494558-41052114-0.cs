    using (var dbContext = new YourDbContext())
    {
        return dbContext.Countries
            .Include(c => c.Districts.Select(d => d.Provinces))
            .ToList();
    }
