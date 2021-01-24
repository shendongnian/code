    class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<string> { "Allan", "Michael", "Jhon", "Smith", "George", "Jhon" };
            var duplicates = list.GroupBy(x => x).Select(r => GetTuple(r.Key, r.Count()))
                                 .Where(x => x.Count > 1)
                                 .Select(c => { c.Count = 1; return c; }).ToList();
            var result = list.Select(v =>
            {
                var val = duplicates.FirstOrDefault(x => x.Name == v);
                if (val != null)
                {
                    if (val.Count != 1)
                    {
                        v = v + " " + val.Count;
                    }
                    val.Count += 1;
                }
                return v;
            }).ToList();
            Console.ReadLine();
        }
        private static FooBar GetTuple(string key, int count)
        {
            return new FooBar(key, count);
        }
    }
    public class FooBar
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public FooBar(string name, int count)
        {
            Count = count;
            Name = name;
        }
    }
