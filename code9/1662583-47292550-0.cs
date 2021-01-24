    byte[] array = new byte[] 
    {
        55, 56, 57, 58, 89, 90, 91, 92
    };
    var even = array.Where((b, i) => i % 2 == 0);
    var odd = array.Except(even);
    Console.WriteLine("Even...");
    foreach (var num in even)
        Console.WriteLine(num);
    Console.WriteLine("Odd...");
        foreach (var num in odd)
    Console.WriteLine(num);
    Console.ReadKey(true);
    // output
    // Even...
    // 55
    // 57
    // 89
    // 91
    // Odd...
    // 56
    // 58
    // 90
    // 92
