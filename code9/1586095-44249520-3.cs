    static void Main()
    {
        var _MissingInt = new List<int> { 106100, 106101 };
        // Simulated range of numbers to remove
        var startNum = 105323;
        var endNum = 106101;
        // Generate a range of numbers based on the user input
        var range = Enumerable.Range(startNum, endNum - startNum + 1);
        // Remove any numbers in the range that are in the _MissingInt list
        range = range.Except(_MissingInt);
        // Output the range with missing ints removed
        Console.WriteLine("Modified Range:");
        Console.WriteLine(string.Join(", ", range));
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
