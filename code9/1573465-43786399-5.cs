      var groupOrders = CafOrders.GroupBy(x => x.CafeteriaClient.AULA)
            .Select(x => new Room
             {
                 Name = x.Key,
                 Meals = x.SelectMany(y => y.OrderedItems)
                          .GroupBy(y => y.Name)
                          .Select(z => new Meal
             {
               Name = z.Key,
               Count = z.Count(),
               Extras = z.Where(t => t.MenuType == "EXTRA")
                         .GroupBy(t => t.Name)
                         .Select(t => new EXTRA
             {
                Name = t.Key,
                UserNames = t.GroupBy(k => new { k.CafClient.Name, 
                                                 k.CafClient.Surname 
                })
                .Select(k => new User {
                Name = k.Key.Name + k.Key.Surname, 
                 Count = k.Count() }).ToList()
                }).ToList()
               }).ToList()
             });
