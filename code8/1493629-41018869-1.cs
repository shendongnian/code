    try 
    {
        int a1 = ExtendedParsing.ParseInt32(a);
        int b1 = ExtendedParsing.ParseInt32(b);
        int c1 = ExtendedParsing.ParseInt32(c);
    }
    catch (ParseException e)
    {
        Console.WriteLine($"Value that I failed to parse: {e.OriginalValue}");
    }
