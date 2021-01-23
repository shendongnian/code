    public class Program
    {
        public static void Main()
        {
            IList<IList<int>> lists = new List<IList<int>>
            {
                new List<int> {1, 2, 4, 4},
                new List<int> {3, 4, 5},
                new List<int> {4, 2, 1, 4},
                new List<int> {1, 2, 2},
                new List<int> {1, 2},
            };
            // There is no Multiset data structure in C#, but we can represent it as a set of tuples,
            // where each tuple contains an item and the number of its occurrences.
            // The dictionary below would not allow to add the same multisets twice, while keeping track of the original lists.
            var multisets = new Dictionary<HashSet<Tuple<int, int>>, IList<int>>(HashSet<Tuple<int, int>>.CreateSetComparer());
            foreach (var list in lists)
            {
                // Count the number of occurrences of each item in the list.
                var set = new Dictionary<int, int>();
                foreach (var item in list)
                {
                    int occurrences;
                    set[item] = set.TryGetValue(item, out occurrences) ? occurrences + 1 : 1;
                }
                // Create sorted set of tuples that we could compare.
                var multiset = new HashSet<Tuple<int, int>>();
                foreach (var kv in set)
                {
                    multiset.Add(Tuple.Create(kv.Key, kv.Value));
                }
                if (!multisets.ContainsKey(multiset))
                {
                    multisets.Add(multiset, list);
                }
            }
            // Print results.
            foreach (var list in multisets.Values)
            {
                Console.WriteLine(string.Join(", ", list));
            }
        }
    }
