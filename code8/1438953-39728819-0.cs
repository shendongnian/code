    public class MultiKeyDictionary<TKey, TValue> : Dictionary<Tuple<TKey, TKey, TKey>, TValue>
    {
        public MultiKeyDictionary()
            : base()
        {
        }
        ...
    }
    class Program
    {
        static void Main(string[] args)
        {
            // C# 6.0 syntax
            var multiKeyDictionary = new MultiKeyDictionary<string, int>();
            multiKeyDictionary.Add(Tuple.Create("key1", "key2", "key3"), 36);
            // C# 7.0 syntax (not yet released).
            var multiKeyDictionary1 = new MultiDictionary<string, int>();
            multiKeyDictionary1.Add(("key1", "key2", "key3"), 36);
        }
    }
