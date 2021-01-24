    var query=configs.GroupBy(w => new{ w.PartId, w.BSId})
                     .Where(g=>g.Count()>1)
                     .Select(g=>new
                               {
                                  g.Key.PartId,
                                  g.Key.BSId,
                                  Count = g.Count(),
                                  EffectiveDate = g.Max(x => x.EffectiveDateUtc)
                               });
