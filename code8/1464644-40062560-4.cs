    static void Main(string[] args)
    {
        Dictionary<Classes, string> data = new Dictionary<Classes, string>
        {
            [new Classes { Name = "a", Namespace = "a" }] = "first",
            [new Classes { Name = "b", Namespace = "b" }] = "second",
        };
        var key = new Classes { Name = "a", Namespace = "a" };
        string result1 = data[key]; // "first"
        string result2;
        if (data.TryGetValue(key, out result2))
        {
            Console.WriteLine(result2); // 'first"
        }
    }
    class Classes
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as Classes;
            if (other == null)
                return false;
            return other.Name == Name &&
                   other.Namespace == Namespace;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^
                   Namespace.GetHashCode();
        }
    }
