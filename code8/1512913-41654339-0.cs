    using System.Entity.Data; //to use Include()
...
    
    Dictionary<string,int> itemOrders = dbContext.Orders.Include(o=> o.Item)
                            .GroupBy(o=> o.Item)
                            .ToDictionary(g => g.Key.Name, g => g.Count());
