    private static void Main()
    {
        Console.WriteLine("Auto 1:");
        Auto A = new Auto("Audi", "A6", "Crna", 2500, 130);
        A.DisplayDetails();
        Console.WriteLine();
        Console.WriteLine("Auto 2:");
        Auto B = new Auto("BMW", "320D", "Plava", 2000, 119);
        B.DisplayDetails();
        Console.WriteLine();
        // These all output the same text
        Auto.ShowComparison(A, B);
        A.ShowComparison(B);
        B.ShowComparison(A);
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
