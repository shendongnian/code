    var query = context
                .products
                .GroupBy(p => p.Name)
                .OrderBy(g => g.Count())
                .Take(3);
    products.Select(p => new
    {
        Name = query.Select(g => g.Key).ToList(),
        Count = query.Select(g => g.Count()).ToList(),
    })
    .FirstOrDefault();
