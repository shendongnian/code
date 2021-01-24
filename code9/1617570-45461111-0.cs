	var myList = new List<string>
                        {
                        "1234567890123",
                        "1234 5678 9012 345",
                        "123456789012 3",
                        "123 12 123 1 23134"
                        };
    foreach(var input in myList)
    {
        var splitted = Regex.Split(input, @"\s+"); // Split on whitespace
        var length = splitted.Sum(x => x.Length); // Compute the total length
        var smallestGroupSize = splitted.Min(x => x.Length); // Compute the length of the smallest chunck
        Console.WriteLine($"Total lenght: {length}, smallest group size: {smallestGroupSize}");
        if (length < 13 || length > 19 || smallestGroupSize < 3)
        {
            Console.WriteLine($"Input '{input}' is incorrect{Environment.NewLine}");
            continue;
        }
        
        Console.WriteLine($"Input '{input}' is correct!{Environment.NewLine}");
    }
