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
                    if (lineItems[outer] == lineItems[inner]) continue;
                    // Create the pair such that the lower of the two values is first
                    // This way "b;a" becomes "a;b"
                    var lesser = string.Compare(lineItems[outer], lineItems[inner], 
                        StringComparison.Ordinal) < 0
                        ? lineItems[outer]
                        : lineItems[inner];
                    var greater = lesser == lineItems[inner] 
                        ? lineItems[outer]
                        : lineItems[inner];
                    var thisPair = $"{lesser};{greater}";
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
