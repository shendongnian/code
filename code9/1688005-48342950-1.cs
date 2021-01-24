    int t = 42;
    object tobj = t;
    if (t == null)
    {
        Console.WriteLine($"It is null");
    }
    else if (t is int i)
    {
        Console.WriteLine($"It is a int of value {i}");
    }
