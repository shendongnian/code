    for ( DateTime date = start; date < end; date = date.AddDays(1) )
    {
        foreach (var hotel in hotels)
        {
            foreach (var roomType in hotels.roomTypes)
            {
                Inventoryttype.Add(new InventoryType(date, hotel.id, roomType.id, num));
            }
        )
    }
