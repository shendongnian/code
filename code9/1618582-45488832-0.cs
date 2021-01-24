    string planets = "1 Mercury Gray \n"
                        + "2 Venus Yellow \n"
                        + "3 Earth Blue \n"
                        + "4 Mars Red \n";
    var lines = planets.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        .Select(s => s.Split(' '))
        .OrderBy(s => s[2])
        .Select(s => string.Join(" ", s))
        .ToArray();
    foreach (var line in lines)
    {
        Console.WriteLine(line);
    }
