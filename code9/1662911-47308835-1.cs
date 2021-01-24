    var results = list1
      .GroupBy(a => a.Domain)
      .Select(g => new DomainModel {        
               DomainName = g.Key,
               CategoryModel = g.GroubY(b => b.Category)
                  .Select(h => new CategoryModel {
                     CategoryName  = h.Key,
                     CapablityModel = h.Select( c => c.CapablityName).ToList()
               }).ToList()
       }).ToList();
 
         
