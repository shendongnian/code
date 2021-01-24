    // Eager loading all District properties and then filtering
    List<CustomClass> assets = dbContext.Assets
        .Include(a => a.District)
        .ToList()
        .Where(a => a.District != null)
        .Select(a => new CustomClass {})
        .ToList();
    // Your initial query.
    List<CustomClass> assets2 = dbContext.Assets
        .Where(a => a.DistrictID != null)
        .Select(a => new CustomClass {})
        .ToList();
