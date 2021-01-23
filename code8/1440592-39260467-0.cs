    var query = Customers
        .Select(c => new
            {
                Name = c.Name,
                NumOrders = Orders.Count(o => o.CustomerId = c.CustomerId)
            });
    foreach (var result in query)
        Console.WriteLine("{0} -> {1}", result.Name, result.NumOrders);
