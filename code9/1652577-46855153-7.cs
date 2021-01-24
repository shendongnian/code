    DisplayMenu();
    string choice = Console.ReadLine();
    while (!choice.StartsWith("Q", StringComparison.OrdinalIgnoreCase))
    {
        DisplayMenu();
        choice = Console.ReadLine();
    }
