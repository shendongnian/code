    private async Task<List<KpiGrounping<int>>> GetGrouping(IQueryable<MyEntityType> query, Expression<Func<MyEntityType, int>> selector)
        {
            return await (from item in entity
                  group itemby new
                  {
                      Geo = item.DimCountry.Geo.Trim(),
                      Platform = item.DimPlatform.Platform.Trim()
                  } into x
                  select new MyGrounpingDto
                  {
                      Geo = x.Key.Geo,
                      Platform = x.Key.Platform,
                      Value = x.Sum(selector)
                  }).ToListAsync();
    }
