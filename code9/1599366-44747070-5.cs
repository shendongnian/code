    static void Main (string [] args)
    {
        var collection = new [] {1, 2, 3, 4, 0, 5, 0, 6, 7};
        var ignoredIndex = collection.IndexOfIgnoring (6, 0);
        Console.WriteLine ($"{ignoredIndex}");
        collection = collection.SetAtIndexOfIgnoring(ignoredIndex, 0, 10).ToArray();
        Console.WriteLine(string.Join(", ", collection));
        Console.ReadLine ();
    }
