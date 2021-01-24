    var numbers = new List<int>();
    while (true)
    {
        int result;
        if (!int.TryParse(Console.ReadLine(), out result)) break;
        if (result % 2 == 0) numbers.Add(result);
    }
    if (numbers.Count > 0)
    {
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
    else
    {
        Console.WriteLine("N/A");
    }
