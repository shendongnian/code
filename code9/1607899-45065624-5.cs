    private static void Main()
    {
        var beverages = new Crate();
        var numBevs = Math.Max(GetInt("How many beverages would you like to enter: "), 0);
        for (int i = 0; i < numBevs; i++)
        {
            Console.WriteLine($"\nEnter beverage #{i + 1} info");
            Console.WriteLine("-----------------------");
            beverages.Add(Crate.GetBeverageFromUser());
            Console.WriteLine("-----------------------\n");
        }
        numBevs = Math.Max(GetInt("How many would you like to be auto-added: "), 0);
        for (int i = 0; i < numBevs; i++)
        {
            beverages.Add(Crate.GetRandomBeverage());
        }
        Console.WriteLine("-----------------------\n");
        Console.WriteLine("\nHere are the contents of the crate:\n");
        Console.ForegroundColor = ConsoleColor.Green;
        beverages.PrintBeverages();
        Console.ResetColor();
        // Wait for input before closing
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
    private static int GetInt(string message)
    {
        int result;
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid number");
            Console.ResetColor();
            Console.Write(message);
        }
        return result;
    }
