     var resources = Db.RESOURCE_Resource
         .Include(i => i.RESOURCE_Value.Where(s => s.ApplicatieID == applicationId))
         .Include(i => i.RESOURCE_Category)
         .Where(w => missingCultureIds.All(a => w.RESOURCE_Value.All(an => an.CultureID != a)));
    var count = resources.Count();
    var results = resources.Skip(pageSize).Take(pageSize*pageNumber);
