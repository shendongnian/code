        var AbsByDepartmentADM = from department in _dbContext.DepartementProjects
                                  join abs in _dbContext.Absences on department.Id equals abs.DepartementProjectID into groupedResult
                                  from groupedResultRight in groupedResult.DefaultIfEmpty()
                                  group groupedResultRight by department.Label into grouped
                                  let NumberOfAbsence = grouped.Count(t => t.DepartementProjectID != null)
                                  let WorkedHours = grouped.Sum(a => a.WorkedHours != null ? a.WorkedHours : 0)
      
                                  select new
                                  {
                                      DepartmentId = grouped.Key,
                                      NumberOfAbsence,
                                      WorkedHours,
                                      AbsencesHours = (8 * NumberOfAbsence - WorkedHours)
                                  };
