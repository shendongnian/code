    class Program
    {
        static void Main(string[] args)
        {
            var cafOrders = new List<OrderedItem>
            {
                new OrderedItem { CafClient = new CafClient { AULA = "Aula 2", Name = "Riki Gervais" }, MealItem = "Pizza Italiana", Type ="EXTRA" },
                new OrderedItem { CafClient = new CafClient { AULA = "Aula 3", Name = "John M Meyer" }, MealItem = "Spaghetti", Type ="EXTRA" },
                new OrderedItem { CafClient = new CafClient { AULA = "Aula 3", Name = "Steve O'Dwayer" }, MealItem = "Sausage", Type ="EXTRA" },
                new OrderedItem { CafClient = new CafClient { AULA = "Aula 3", Name = "Allan Parker" }, MealItem = "Pasta", Type ="EXTRA" },
                new OrderedItem { CafClient = new CafClient { AULA = "Aula 6", Name = "John Susack" }, MealItem = "Riggatoni", Type ="EXTERNAL" },
            };
            var data = cafOrders.GroupBy(o => o.CafClient.AULA)
                        .Select(g => new
                        {
                            Room = g.First().CafClient.AULA,
                            NumberOfRooms = g.Count(),
                            Clients = g.Where(x => x.Type == "EXTRA").Select(e => e.CafClient.Name),
                            MealItemToCount = g.GroupBy(m => m.MealItem).ToDictionary(k => k.First().MealItem, v => v.Count())
                        })
                        .ToList();
        }
        class OrderedItem
        {
            public string MealItem { get; set; }
            public string Type { get; set; }
            public CafClient CafClient { get; set; }
        }
        class CafClient
        {
            public string AULA { get; set; }
            public string Name { get; set; }
        }
    }
