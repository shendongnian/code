    List<Users> UList = db.Users
                          .Where(a => a.isdelete == false)
                          .GroupBy(a => a.UserId)
                          .Select(g => new 
                                       {
                                         count = g.Count(), 
                                         data =  g.OrderByDescending(a => a.datetime).First()
                                       }
                          );
