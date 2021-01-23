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
            // Create sorted sets from lists of lists.
            var sortedSets = new List<SortedSet<int>>(lists.Count);
            foreach (var list in lists)
            {
                sortedSets.Add(new SortedSet<int>(list));
            }
            // Get rid of duplicated sets.
            var uniqueSets = new HashSet<SortedSet<int>>(sortedSets, SortedSet<int>.CreateSetComparer());
            // Print results.
            foreach (var set in uniqueSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }
    }
