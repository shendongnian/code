    for ( DateTime date = start; date < end; date = date.AddDays(1) )
    {
        foreach (var hotel in hotels)
        {
            Inventoryttype.Add(new InventoryType(date, hotel.id, "KB", num));
            Inventoryttype.Add(new InventoryType(date, hotel.id, "QB", num));
        )
    }
