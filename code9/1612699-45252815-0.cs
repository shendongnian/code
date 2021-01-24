    var lineNumber = 0;
    var sum = 0;
    while (true)
    {
        var line = Console.ReadLine();
        if (string.IsNullOrEmpty(line))
            break;
        if (lineNumber++ % 3 == 0)
            sum += int.Parse(line);
    }
    Console.WriteLine(sum);
