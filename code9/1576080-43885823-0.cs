    if (o is int i)
    {
        Console.WriteLine(i.ToString());
    }
    else if (o is string && int.TryParse((string)o, out int i))
    {
        Console.WriteLine(i.ToString());
    }
