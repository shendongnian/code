    var UList = (db.Users
                          .Where(a => a.isdelete == false)
                          .GroupBy(a => a.UserId)
                          .Select(g => new MyNewClass
                                       {
                                         Count = g.Count(), 
                                         User =  g.OrderByDescending(a => a.datetime).First()
                                       }
                          ))
                           .Skip(skip)
                           .Take(pageSize)
                           .ToList();
