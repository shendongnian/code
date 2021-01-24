    var result = list.GroupBy(x=> new { x.Code, x.Type})
                     .Select(g=> 
                                 new { 
                                       Code = g.Key.Code, 
                                       Type= g.Key.Type, 
                                       Point = g.Sum(x=>x.Point)
                                 })
                     .ToList();
