    string planets = "1 Mercury Gray \n"
                        + "2 Venus Yellow \n"
                        + "3 Earth Blue \n"
                        + "4 Mars Red \n";
    var lines = planets.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        .OrderBy(s => s.Split(' ')[2])
        .ToArray();
    foreach (var line in lines)
    {
        Console.WriteLine(line);
    }
