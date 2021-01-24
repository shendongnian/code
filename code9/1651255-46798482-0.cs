    var groceryQuantities = groceries.Select(g => new
    {
        g.ItemName,
        Quantities = g.ItemTypes
            .Where(it => it.Weight == 1)
            .Select(it => it.Quantity)
            .ToList()
    }).ToList();
