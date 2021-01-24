    private static void Main()
    {
        var data = File.ReadAllLines(@"f:\public\temp\temp.txt");
        var pairCount = new Dictionary<string, int>();
        foreach (var line in data)
        {
            var lineItems = line.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            for (var outer = 0; outer < lineItems.Length - 1; outer++)
            {
                for (var inner = outer + 1; inner < lineItems.Length; inner++)
                {
                    var outerComparedToInner = string.Compare(lineItems[outer], 
                        lineItems[inner], StringComparison.Ordinal);
                    // If both items are the same character, ignore them and keep looping
                    if (outerComparedToInner == 0) continue;
                    // Create the pair such that the lower of the two 
                    // values is first, so that "b;a" becomes "a;b"
                    var thisPair = outerComparedToInner < 0
                        ? $"{lineItems[outer]};{lineItems[inner]}"
                        : $"{lineItems[inner]};{lineItems[outer]}";
                    if (pairCount.ContainsKey(thisPair))
                    {
                        pairCount[thisPair]++;
                    }
                    else
                    {
                        pairCount.Add(thisPair, 1);
                    }
                }
            }
        }
        Console.WriteLine("Pair\tCount\n----\t-----");
        foreach (var val in pairCount.OrderBy(i => i.Key))
        {
            Console.WriteLine($"{val.Key}\t{val.Value}");
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
