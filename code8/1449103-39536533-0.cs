    var result = list.GroupBy(x=>new {x.GroupID, x.Location,x.Place})
                     .Select(g=> new 
                             { 
                               GroupID = g.Key.GroupID, 
                               Location = g.Key.Location, 
                               Place = x.Key.Place
                             });
