    var bestSellingProducts = products
        .OrderByDescending(product=> product.Orders.Count())
        .Select(product => new
        {   // select only the properties you plan to use, for instance
            Id = product.Id,
            Name = product.Name,
            Stock = product.Stock
            Price = product.Price,
        });
        .Take(2);
