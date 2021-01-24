    var count = Db.RESOURCE_Resource
        .Include(i => i.RESOURCE_Value.Where(s => s.ApplicatieID == applicationId))
        .Include(i => i.RESOURCE_Category)
        .Where(w => missingCultureIds.All(a => w.RESOURCE_Value.All(an => an.CultureID != a))).Count();
    var results = Db.RESOURCE_Resource
        .Include(i => i.RESOURCE_Value.Where(s => s.ApplicatieID == applicationId))
        .Include(i => i.RESOURCE_Category)
        .Where(w => missingCultureIds.All(a => w.RESOURCE_Value.All(an => an.CultureID != a))).Skip(pageSize).Take(pageSize*pageNumber);
