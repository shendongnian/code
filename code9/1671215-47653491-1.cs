    var allRegionGroups = allOfficeLocators
        .GroupBy(ol => ol.Geography)
        .Select(gGroup => new
        {
            GeographyName = gGroup.Key,
            Countries = gGroup
                .GroupBy(ol => ol.Country)
                .Select(cGroup => new
                {
                    Country = cGroup.Key,
                    States = cGroup
                      .GroupBy(ol => ol.State)
                      .Select(sGroup => new
                      {
                          State = sGroup.Key,
                          OfficeList = sGroup
                           .Select(ol => new { OfficeId = ol.id, ol.OfficeName })
                           .ToList()
                      })
                     .ToList()
                })
                .ToList()
        })
        .ToList();
