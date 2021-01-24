    // The part in parenthesis specifies that the keys will be 
    // case-insensitive when doing comparisons, so you can search 
    // for "john", "John", or "JOHN", and get the same value back
    private static  Dictionary<string, int> nameValues = 
        new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
    {
        {"John", 1},
        {"Jimmy", 2},
        {"Mark", 3}
    };
