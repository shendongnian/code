    Employees.GroupBy(e => e.Department.Name)
                              .Select(g =>
                                new {
                                    Department = g.Key,
                                    SalaryAvg = g.Average(x => x.Salaries.OrderByDescending(s => s.Date).FirstOrDefault().Amount)
                                });
