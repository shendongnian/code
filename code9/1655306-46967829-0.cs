    var prodsalesbygender = context.OrderProducts
        .GroupBy(op => new
        {
            Gender = op.Order.Person.Gender
        })
        .Select(g => new
        {
            Gender = g.Key.Gender,
            Products = g.GroupBy(op => op.Product)
            .Select(a => new
            {
                ProductName = a.Key.Name,
                Total = a.Sum(op => op.Qty) * a.Select(op => op.Product.Price).FirstOrDefault()
            })
            .OrderBy(a => a.ProductName)
        });
    foreach (var x in prodsalesbygender)
    {
        Console.WriteLine(x.Gender);
        foreach (var a in x.Products)
            Console.WriteLine($"\t{a.ProductName} - {a.Total}");
    }
