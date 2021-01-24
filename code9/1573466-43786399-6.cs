      public class Meal
      {
            public string Name { get; set; }
            public int Count { get; set; }
      }
      
     public class Room
     {
            public string Name { get; set; }
            public List<Meal> Meals { get; set; }
            public List<EXTRA> Extras { get; set; }
      }
   
       var groupOrders = CafOrders.GroupBy(x => x.CafeteriaClient.AULA)
            .Select(x => new Room
             {
                 Name = x.Key,
                 Meals = x.SelectMany(y => y.OrderedItems)
                          .Where(y => y.MenuType != "EXTRA")
                          .GroupBy(y => y.Name)
                          .Select(z => new Meal
                           {
                               Name = z.Key,
                               Count = z.Count()
                           }).ToList(),
                 Extras = x.SelectMany(y => y.OrderedItems)
                          .Where(y => y.MenuType == "EXTRA")
                          .GroupBy(y => y.Name)
                          .Select(z => new EXTRA
                          {
                              Name = z.Key,
                              Count = z.Count(),
                              UserNames = z.GroupBy(k => new { k.CafClient.Name, 
                                                               k.CafClient.Surname })
                                           .Select(k => new User {
                                               Count = k.Count(), 
                                               Name = k.Key.Name + k.Key.Surname })
                                             .ToList()
                          }).ToList()
             });              
  
 
