    var strings = new[]
    {
        "column1:abcd",
        "qwerty:asdfg",
        "1234:5678"
    };
    foreach (var search in strings)
    {
        string column;
        string value;
        if (TryGetValue(search, out column, out value))
        {
            Console.WriteLine($"Column: '{column}'\tValue: '{value}'");
        }
        else
        {
            Console.WriteLine("Invalid syntax");
        }
    }
