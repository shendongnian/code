    string a = "1";
    string b = "b";
    string c = "3";
    int aInt, bInt, cInt;
    if (!int.TryParse(a, out aInt))
    {
        //report e.g.
        Console.WriteLine($"Could not parse {nameof(a)}");
    }
    if (!int.TryParse(b, out bInt))
    {
        //report e.g.
        Console.WriteLine($"Could not parse {nameof(b)}");
    }
    if (!int.TryParse(c, out cInt))
    {
        //report e.g.
        Console.WriteLine($"Could not parse {nameof(c)}");
    }
