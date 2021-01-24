    string name = "stranger";
    while (true)
    {
        Console.Write("Input some text: ");
        Console.WriteLine(TryGetName(Console.ReadLine(), name, out name)
            ? $"I detected your name is: '{name}'"
            : $"I did not detect your name that time, {name}.");
        Console.WriteLine();
    }
    
