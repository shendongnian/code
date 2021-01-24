    class Data
    {
        public int Key { get; }
        public string Name { get; }
        public Data(int key, string name)
        {
            Key = key;
            Name = name;
        }
    }
	class Program
    {
        static void Main(string[] args)
        {
            KeyExtractorDictionary<int, Data> dictionary =
                new KeyExtractorDictionary<int, Data>(d => d.Key)
                {
                    new Data(1, "FooBar"),
                    new Data(2, "FizzBang")
                };
        }
    }
