    private static void Main()
    {
        List<int> original = new List<int> {1, 2, 6, 7, 8, 9};
        List<int> newItems = new List<int> {1, 2, 3, 4, 5, 6};
        Console.WriteLine("Before Splice:");
        Console.WriteLine($"original: {string.Join(",", original)}");
        Console.WriteLine($"newItems: {string.Join(",", newItems)}");
        // Transfer items '3', '4', and '5' from 'newItems' to 'original' at index 2
        original.Splice(2, newItems, 2, 5);
        Console.WriteLine("\nAfter Splice:");
        Console.WriteLine($"original: {string.Join(",", original)}");
        Console.WriteLine($"newItems: {string.Join(",", newItems)}");
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
