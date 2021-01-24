    static void Main()
    {
        var allNumbers = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Enter integer #{i + 1}: ");
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Write(" - Invalid input, try again: ");
            }
            allNumbers.Add(input);
        }
        Console.WriteLine($"\nThank you! The smallest number you entered is: {allNumbers.Min()}");
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
