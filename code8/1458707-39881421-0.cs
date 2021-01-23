        dbContext.Visits.Where(x => x.IsActive)
                     .SelectMany(x => x.VisitLines, (v, vl) => new
                    {
                      v.Id,
                      vl.ProcedureId
                    })
    .GroupBy(x => x.ProcedureId)
                              .Select(x => new
                              {
                                  Id = x.Key,
                                  VisitCount = x.Count()
                              }).ToArray();
