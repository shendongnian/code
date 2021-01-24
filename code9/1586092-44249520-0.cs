    static void Main()
    {
        var originalList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        // Output the new list
        Console.WriteLine("Original list:");
        Console.WriteLine(string.Join(", ", originalList));
        // Simulated range of numbers to remove (from 3 to 7)
        var startNum = 3;
        var endNum = 7;
        // Generate a range of numbers based on the user input
        var range = Enumerable.Range(startNum, endNum - startNum + 1);
        // Remove any numbers in the range from the original list
        originalList = originalList.Except(range).ToList();
        // Output the new list
        Console.WriteLine("New list:");
        Console.WriteLine(string.Join(", ", originalList));
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
