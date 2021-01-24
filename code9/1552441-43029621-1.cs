    var order = new Order { Id = 1, Quantity = 5, Product = new Product { Id = 1, Name = "CPU", Price = 500 } };
    var newOrder = Mapper.Map<Order, Order>(order);
    	
    //Ouputs: true
    Console.WriteLine(Object.ReferenceEquals(newOrder.Product, order.Product));
