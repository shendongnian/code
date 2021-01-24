    var query= from s in context.Sites
               select t new SiteSummary
                {
                    SiteId = s.SiteId,
                    Name = s.Name,
                    Code = s.Code,
                    RegisteredCount =s.Patiens.SelectMany(e=>e.PatientCycles.Select(y=>y.WorkflowStateId ))
                                              .Sum(x => x!= WorkflowStateType.Terminated ? 1 : 0),
                    ScreenFailedCount = s.Patiens.SelectMany(e=>e.PatientCycles.Select(y=>y.WorkflowStateId ))
                                                 .Sum(x => x== WorkflowStateType.Terminated ? 1 : 0)
                };
