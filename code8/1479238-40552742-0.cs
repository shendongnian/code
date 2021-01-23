    var classResult = from result in results
                      group result by result.PlanningID into grouping
                      select new ClassResult
                      {
                          PlanningID = grouping.Key,
                          PlanningStatus = grouping.Select(item => new PlanningStatus {
                              PlanningStatus = item.PlanningStatus,
                              Private = item.Private,
                              Social = item.Social
                          }).ToList()
                      };
