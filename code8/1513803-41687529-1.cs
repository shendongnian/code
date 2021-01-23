    public class Program
    {
        public static void Main()
        {
            IList<IList<int>> lists = new List<IList<int>>
            {
                new List<int> {1, 2, 4, 4},
                new List<int> {3, 4, 5},
                new List<int> {4, 2, 1, 4}
            };
            // Create dictionary of unique sets associated with original lists.
            var uniqueSets = new Dictionary<HashSet<int>, IList<int>>(HashSet<int>.CreateSetComparer());
            foreach (var list in lists)
            {
                var hashSet = new HashSet<int>(list);
                if (!uniqueSets.ContainsKey(hashSet))
                {
                    uniqueSets.Add(hashSet, list);
                }
            }
            // Print results.
            foreach (var list in uniqueSets.Values)
            {
                Console.WriteLine(string.Join(", ", list));
            }
        }
    }
