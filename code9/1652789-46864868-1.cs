    var products = context.products
                .GroupBy(p => p.Name)
                .OrderBy(g => g.Count())
                .Take(3)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .ToList();
    List<string> names = products.Select(p => p.Name).ToList();
    List<int> counts = products.Select(p => p.Count).ToList();
