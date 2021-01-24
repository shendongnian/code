    int sum = 0;
    var values = new Dictionary<string, int>
    {
        { "a", 1 },
        { "b", 2 },
        { "c", 3 }
    };
    var input = Console.ReadLine().Split('+');
    foreach (string variable in input)
    {
        sum += values.ContainsKey(variable) ? values[variable] : 0;
    }
    Console.WriteLine("Sum: {0}", sum);
