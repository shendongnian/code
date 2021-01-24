    public void Validate()
    {
        var entries = GetEntriesFromFile(@"C:\entries.txt");
        var parentAmounts = new Dictionary<int, int>();
        var childAmounts = new Dictionary<int, int>();
        foreach (var e in entries)
        {
            if (e.Reference != null)
                childAmounts.GetOrAdd(e.Reference.Value, amount => amount + e.TotalAmount);
            else
                parentAmounts[e.Id] = e.TotalAmount;
        }
        foreach (var parentId in parentAmounts.Keys)
        {
            var parentTotal = parentAmounts[parentId];
            if (childAmounts.TryGetValue(parentId, out var childTotal))
            {
                if (childTotal == parentTotal)
                    Console.WriteLine($"Entry with Id {parentId} is valid");
                else
                    Console.WriteLine($"Entry with Id {parentId} is INVALID");
            }
            else
            {
                Console.WriteLine("Entry with Id {0} is valid", parentId);
            }
        }
    }
    private static IEnumerable<Entry> GetEntriesFromFile(string file)
    {
        foreach (var line in File.ReadLines(file))
            yield return this.GetEntryFromLine(line);
    }
    private static Entry GetEntryFromLine(string line)
    {
        var parts = line.Split('|');
        var entry = new Entry
                    {
                        Id = int.Parse(parts[0]),
                        TotalAmount = int.Parse(parts[1])
                    };
        if (parts.Length == 3)
            entry.Reference = int.Parse(parts[2]);
        return entry;
    }
