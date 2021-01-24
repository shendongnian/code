    private static void Main()
    {
        var data = File.ReadAllLines(@"f:\public\temp\temp.txt");
        var pairCount = new Dictionary<string, int>();
        foreach (var line in data)
        {
            var lineItems = line.Split(';');
            for (var outer = 0; outer < lineItems.Length - 1; outer++)
            {            
                for (var inner = outer + 1; inner < lineItems.Length; inner++)
                {
                    // Only needed if a line may contain the same letter more than once
                    if (lineItems[outer] == lineItems[inner]) continue;
                    var thisPair = $"{lineItems[outer]};{lineItems[inner]}";
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
