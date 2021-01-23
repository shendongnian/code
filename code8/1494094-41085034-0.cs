    var myQuery = from r in MyContext.A
                                 .Include(x => x.B.Select(y => y.C))
                                 .Where(a => a.sku == 2)
                                  Select new MyDTO
                                  {
                                     ...
                                  }
    var res = myQuery.FirstOrDefault();
