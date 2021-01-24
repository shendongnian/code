    var rro = JsonConvert.DeserializeObject<RatesResponseObject>(json);
    foreach (Hotel hotel in rro.hotels)
    {
        Console.WriteLine("Hotel ID: " + hotel.hotel_id);
        Console.WriteLine();
        foreach (var kvp in hotel.room_types)
        {
            Console.WriteLine("Room Type: " + kvp.Key);
            Console.WriteLine("Number of Rooms: " + kvp.Value.num_rooms);
            Console.WriteLine("Final Price: " + kvp.Value.final_price);
            Console.WriteLine();
        }
    }
