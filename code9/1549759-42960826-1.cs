    foreach(Artist a in artistList)
    {
        Console.WriteLine(a.Name);
        Console.WriteLine(a.ID);
        foreach(string car in a.Cars)
        {
            Console.WriteLine(car);
        }
    }
