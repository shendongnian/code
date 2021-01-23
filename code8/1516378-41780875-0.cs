    var res = dbContext.InstitutionEnquiry
    .Where(u => u.City == data.Trim().ToLower())
    .GroupBy(u => new {
        AddressLine3 = u.AddressLine3.Trim().ToLower(),
        City = u.City.Trim().ToLower()
     }).Select(g => new {
         g.Key.AddressLine3,
         g.Key.City,
         Count = g.Count()
    }).ToList();
