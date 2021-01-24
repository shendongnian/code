    var shipmentItemsList = shippedItems // This is logically grouped by shipment id
        .SelectMany(s => s.ShipmentItems) // First flatten the list
        .GroupBy(i => i.ItemId) // Now group it by item id
        .Select(g => new
        {
            ItemId = g.Key,
            Quantity = g.Sum(item => item.Quantity)
        }) // now get the quantity for each group
        .ToList();
