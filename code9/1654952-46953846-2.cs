    public class Example
    {
        public Example(HashSet<int> a, HashSet<int> b)
        {
            ListA = a;
            ListB = b;
        }
        public HashSet<int> ListA { get; set; }
        public HashSet<int> ListB { get; set; }
    }
    static IEnumerable<int> GetDistinctFromListA(HashSet<Example> hs, int b)
    {
        var rv = hs.Aggregate(new HashSet<int>(), (acc, el) =>
        {
            if (el.ListB.Contains(b)) acc.UnionWith(el.ListA);
            return acc;
        });
        return rv;
    }
    static void Main(string[] args)
    {
        var hs = new HashSet<Example>();
        hs.Add(new Example(new HashSet<int> { 1 }, new HashSet<int> { 100, 200 }));
        hs.Add(new Example(new HashSet<int> { 2, 3, 4, 5 }, new HashSet<int> { 100, 200, 300 }));
        hs.Add(new Example(new HashSet<int> { 6, 9, 12 }, new HashSet<int> { 200, 300 }));
        foreach (var b in hs.SelectMany(e => e.ListB).Distinct())
            Console.WriteLine($"{b} => {string.Join(",", GetDistinctFromListA(hs, b))}");
        Console.ReadLine();
    }
