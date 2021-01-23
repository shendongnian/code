    for ( DateTime date = start; date < end; date = date.AddDays(1) )
    {
        Inventoryttype.Add(new InventoryType(date, "123", "KB", num));
        Inventoryttype.Add(new InventoryType(date, "124", "qB", num));
    }
