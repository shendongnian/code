    // All the Indicator records
    IQueryable<Indicator> data = _context.Indicators;
    // All months from database 
    IQueryable<string> months = data.Select(i => i.Month).Distinct();
    // All cities
    IQueryable<string> cities = data.Select(i => i.City).Distinct();
    // Now your query
    var results = (from string month in months
                   from string city  in cities
                   select new
                   {
                      month = month,
                      city  = city,
                      count = data.Where(i => i.Month == month && i.City == city)
                                  .Select(i => i.NumberOfHouses)
                                  .FirstOrDefault() 
                   }).ToList();
