    private static void Main()
    {
        /* int is the integer type, while string is the "tag" object */
        var animals = new IntRangeArray();
        animals.Add(1, "dog");
        Console.WriteLine(animals);
        animals.Add(2, "dog");
        Console.WriteLine(animals);
        /* AddRange with C#7.0 ValueTuple */
        animals.AddRange(Tuple.Create(4, 14), "dog");
        Console.WriteLine(animals);
            
        animals.Add(3, "dog");
        Console.WriteLine(animals);
        animals.AddRange(new int[] { 15, 17, 18, 19 }, "dog");
        Console.WriteLine(animals);
        animals.Add(16, "cat");
        Console.WriteLine(animals);
        animals.Remove(8);
        Console.WriteLine(animals);
        Console.WriteLine(animals.At(11));
        animals.RemoveWithTag("dog");
        Console.WriteLine(animals);
        Console.WriteLine(animals.TagOf(16));
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
