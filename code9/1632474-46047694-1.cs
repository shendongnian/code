        static void Main(string[] args)
        {
            // Initialize the list
            var result = new []
            {
                new  { Month = 2, Count = 15 },
                new  { Month = 5, Count = 11 },
                new  { Month = 9, Count = 82 }
            }.ToList();
            // Generate a List with 0 in Range
            var lowestKey = result.Min(x => x.Month);
            var highestKey = result.Max(x => x.Month);          
            
            result = result.Union(
                Enumerable.Range(lowestKey, highestKey - lowestKey)
                .Where(e => !result.Any(r => r.Month == e))
                .Select(s => new  { Month = s, Count = 0 })
                ).OrderBy(o => o.Month).ToList();
            foreach (var data in result)
            {
                Console.WriteLine("Month " + data.Month + "  Count " + data.Count);
            }
            Console.ReadKey();
        }
