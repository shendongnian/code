    var salaryEstimatesWithJobs = _dbContext.Jobs
                                  .Include(s => s.SalaryEstimates)
                                  .Where(j => !j.IsDeleted && !j.IsPrivate)
                                  .GroupBy(e=>e.SalaryEstimateId)
                                  .Select(g => new SalaryEstimatesWithJobCountViewModel
                                              {
                                               SalaryEstimate = g.FirstOrDefault().SalaryEstimate,
                                               JobCount = g.Count()
                                              });
