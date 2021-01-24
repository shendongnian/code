    Type fooType = typeof(String);
    if (fooType.IsAssignableFrom(typeof(int)))
    {
        Console.WriteLine("Will not show.");
    }
    
    if (fooType.IsAssignableFrom(typeof(string)))
    {
        Console.WriteLine("This will show.");
    }
