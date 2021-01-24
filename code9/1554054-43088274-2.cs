    var result = list.GroupBy(x=> x.Code)
                         .Select(g=> 
                                     new { 
                                           Code = g.Key.Code, 
                                           PointType1= g.Where(x=>x.Type==1)
                                                        .Sum(x=>x.Point)
                                                       Key.Type, 
                                           PointType2 = g.Where(x=>x.Type==2)
                                                         .Sum(x=>x.Point)
                                     })
                         .ToList();
