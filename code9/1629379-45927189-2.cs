     var summary = (from c in Cars
                      group c by new { c.CarName, c.DeptId } into grp
                      join d in Departments on grp.Key.DeptId equals d.Id
                      select new CarViewModel { CarName = grp.Key.CarName, 
                                                DeptName =  d.DeptName, 
                                                Status = grp.Sum(s => s.Status) })
                    .ToList();
