    Console.Write("Enter VillainId: ");
    // asks to user input
    while (!int.TryParse(Console.ReadLine(), out VillainId))
    // while the conversion is not successfull
    {
        Console.WriteLine("You need to enter a valid Villain Id!");
        Console.Write("Enter VillainId: ");
        // asks for user to input valid data
    }
