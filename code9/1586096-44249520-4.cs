    static void Main()
    {
        var _MissingInt = new List<int> { 106100, 106101 };
        var startNum = 105323;
        var endNum = 106101;
        var range = Enumerable.Range(startNum, endNum - startNum + 1).Except(_MissingInt);
        // Output the range with missing ints removed
        Console.WriteLine("Modified Range:");
        Console.WriteLine(string.Join(", ", range));
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
