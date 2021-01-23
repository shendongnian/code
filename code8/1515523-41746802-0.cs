    var results = sites.SelectMany(s => s.Zones.Select(z => new {ParentSite = s, Zone = z}))
                                   .SelectMany(x => x.Zone.Placements.Select(p => new {ParentSite = x.ParentSite,
                                                                                      ParentZone = x.Zone,
                                                                                      Placement = p}))
                                  .Where(x => x.Placement.Id == 2 && x.ParentZone.Id == zoneId)
                                  .ToList();
