    var pairs = data.SelectMany(x => x.IndexPattern
                                      .Split(",")
                                      .Select(y => new {Index = y, Type = x.Type});
    var res = from p in pairs
              group p by new { p.Index, p.Type } into grp
              select new {
                Index = grp.Key.Index,
                        grp.Key.Type,
                        grp.Count()
              };
