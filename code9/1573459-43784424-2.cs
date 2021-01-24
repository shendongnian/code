    var cafOrders = new CafOrders
    {
        OrderedItems = new List<OrderedItems>
        {
            new OrderedItems
            {
                CafClient = new CafeteriaClients { AULA = "Aula 2", Name = "Riki ", Surname = "Gervais" },
                Name = "Pizza Italiana",
                MenuType = "EXTRA"
            },
            new OrderedItems
            {
                CafClient = new CafeteriaClients { AULA = "Aula 3", Name = "John ", Surname = "M Meyer" },
                Name = "Spaghetti",
                MenuType = "EXTRA"
            },
            new OrderedItems
            {
                CafClient = new CafeteriaClients { AULA = "Aula 3", Name = "Steve", Surname = "O'Dwayer" },
                Name = "Sausage",
                MenuType = "EXTRA"
            },
            new OrderedItems
            {
                CafClient = new CafeteriaClients { AULA = "Aula 3", Name = "Allan", Surname = "Parker" },
                Name = "Pasta",
                MenuType = "EXTRA"
            },
            new OrderedItems
            {
                CafClient = new CafeteriaClients { AULA = "Aula 6", Name = "John", Surname = "Susack" },
                Name = "Riggatoni",
                MenuType = "EXTERNAL"
            }
        }
    };
    
    var orders = cafOrders.OrderedItems.GroupBy(o => o.CafClient.AULA)
                .Select(g => new
                {
                    Room = g.First().CafClient.AULA,
                    NumberOfRooms = g.Count(),
                    Clients = g.Where(x => x.MenuType == "EXTRA").Select(e => e.CafClient.Name),
                    MealItemToCount = g.GroupBy(m => m.Name).ToDictionary(k => k.First().Name, v => v.Count())
                })
                .ToList();
            }
