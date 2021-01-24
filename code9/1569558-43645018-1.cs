    void Main()
    {
        var data = new
        {
            Lookup = new TripleKeyedDictionary<Fruit, string, string, string>
            {
                { Tuple.Create(Fruit.Banana, "b", "c"), "value" }
            }
        };
        
        var binding = new Binding("Lookup[Banana,b,c]");
        binding.Mode = BindingMode.OneWay;
        binding.Source = data;
        binding.FallbackValue = "fallback";
        binding.TargetNullValue = "null";
        
        var block = new TextBlock().Dump();
        block.SetBinding(TextBlock.TextProperty, binding);
    }
    
    // Define other methods and classes here
    public enum Fruit
    {
        Apple, Banana, Cactus
    }
    public class TripleKeyedDictionary<TKey1, TKey2, TKey3, TValue> : Dictionary<Tuple<TKey1, TKey2, TKey3>, TValue>
    {
        public TValue this [TKey1 key1, TKey2 key2, TKey3 key3]
        {
            get { return this[Tuple.Create(key1, key2, key3)]; }
            set { this[Tuple.Create(key1, key2, key3)] = value; }
        }
    }
