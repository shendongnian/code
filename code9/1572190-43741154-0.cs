    using (var context = new EFRecipesContext()) {
        var order = new Order { OrderId = 1, OrderDate = new DateTime(2010, 1, 18) };
        context.Orders.Add(order);
        var item1 = new Item { SKU = 1729, Description = "Backpack", Price = 29.97M };
        var oi1 = new OrderItem { Order = order, Item = item, Count = 1 };
        context.OrderItems.Add(oi1);
        var item2 = new Item { SKU = 2929, Description = "Water Filter", Price = 13.97M };
        var oi2 = new OrderItem { Order = order, Item = item, Count = 3 };
        context.OrderItems.Add(oi2);
        var item3 = new Item { SKU = 1847, Description = "Camp Stove", Price = 43.99M };
        var oi3 = new OrderItem { Order = order, Item = item, Count = 1 };
        context.OrderItems.Add(oi3);
        
        context.SaveChanges();
    }
