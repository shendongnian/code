    var groups = aList
       .SelectMany(a => a.nestedList.Select(b => new { A = a, B = b }))
       .GroupBy(x => new { x.B.innerid, x.B.innername })
       .Select(g => new { 
           g.Key.innerid, 
           g.Key.innername, 
           aItems = g.Select(x => new { x.A.id, x.A.name }) 
        });
