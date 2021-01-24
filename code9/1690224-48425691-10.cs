    public class Entry
    {
        public int Id { get; set; }
        public int TotalAmount { get; set; }
        public int? Reference { get; set; }
    }
    public static class EntryValidator
    {
        public static void Validate(string file)
        {
            var entries = GetEntriesFromFile(file);
            var childAmounts = new Dictionary<int, int>();
            var nonChildAmounts = new Dictionary<int, int>();
            foreach (var e in entries)
            {
                if (e.Reference is int p)
                    childAmounts.AddOrUpdate(p, e.TotalAmount, (_, n) => n + e.TotalAmount);
                else
                    nonChildAmounts[e.Id] = e.TotalAmount;
            }
            foreach (var id in nonChildAmounts.Keys)
            {
                var expectedTotal = nonChildAmounts[id];
                if (childAmounts.TryGetValue(id, out var childTotal) &&
                    childTotal != expectedTotal)
                {
                    Console.WriteLine($"Entry with Id {id} is INVALID");
                }
                else
                {
                    Console.WriteLine($"Entry with Id {id} is valid");
                }
            }
        }
        private static IEnumerable<Entry> GetEntriesFromFile(string file)
        {
            foreach (var line in File.ReadLines(file))
                yield return GetEntryFromLine(line);
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
    }
