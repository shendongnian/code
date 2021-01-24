    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.BackgroundColor = ConsoleColor.Red;
    // only write without new line
    Console.Write($"The selected row {selection} is not found in the database.");
    Console.ResetColor();
    Console.WriteLine(); // if necessary
    Console.ReadLine();
    Environment.Exit(0);
