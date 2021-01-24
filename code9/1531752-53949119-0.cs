    var result = 
        ( from   p in List
          group  p by p.Value into g
          select new { 
            GroupId = g.OrderByDescending(x=>x.Id).FirstOrDefault().GroupId,
            ValueA = g.OrderByDescending(x => x.Id).FirstOrDefault().ValueA 
          }
        ).ToList();
