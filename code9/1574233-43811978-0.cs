    // method syntax
    var result  = data.GroupBy(key => key.Line3, item => item.Line2)
                      .Select(g => new
                      {
                          g.Key,
                          Line2 = g.ToList()
                      }).ToList();
    // query syntax
    var result = from item in data
                 group item.Line2 by item.Line3 into g
                 select new
                 {
                     g.Key,
                     Line2 = g.ToList()
                 };
