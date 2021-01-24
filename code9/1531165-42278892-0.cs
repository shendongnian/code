    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Class1<int, string>();
            obj.Dictionary.Add(1, "hello");
        }
    }
    class Class1<Tkey, Tvalue>
    {
        public Dictionary<Tkey, Tvalue> Dictionary { get; set; }
    }
