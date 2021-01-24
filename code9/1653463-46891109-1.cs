    var query =context.FinishedWork.GroupBy(fw=>new{fw.Employee.Name,fw.Department.DepartmentName})
                                   .Select(g=>g.GroupBy(fw=>fw.JobTypeCode )
                                               .Select(g1=>new {g.Key.Name,
                                                                g.Key.DepartmentName,
                                                                g1.Key,
                                                                g1.Count()}));
