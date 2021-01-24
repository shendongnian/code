    var groceryQuantities = groceries.Select(g => new
    {
        g.ItemName,
        TotalQuantity = g.ItemTypes
            .Where(it => it.Weight == 1)
            .Sum(it => it.Quantity)
    }).ToList();
