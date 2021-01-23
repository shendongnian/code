    if (row is ElectricalDriven)
    {
        Console.WriteLine($"Price: {((ElectricalDriven)row).Price}");
    }
    else if (row is GasolinDriven)
    {
        Console.WriteLine($"Price: {((GasolinDriven)row).Price}");
    }
