    DateTime dt;
    if (DateTime.TryParseExact("July 2016", "MMMM yyyy", null, DateTimeStyles.None, out dt))
    {
        // Parse success
        Console.WriteLine(dt);
    }
    else
    {
        // parse failed
        Console.WriteLine("Failed");
    }
