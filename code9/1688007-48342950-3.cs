    int t = 42;
    object tobj = t;
    if (tobj == null)
    {
        Console.WriteLine($"It is null");
    }
    else if (tobj is int i)
    {
        Console.WriteLine($"It is a int of value {i}");
    }
