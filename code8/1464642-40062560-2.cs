    static void Main(string[] args)
    {
        Dictionary<Classes, string> data = new Dictionary<Classes, string>
        {
            [new Classes { Name = "a", Namespace = "a" }] = "first",
            [new Classes { Name = "b", Namespace = "b" }] = "second",
        };
        string result;
        if (data.TryGetValue(new Classes { Name = "a", Namespace = "a" }, out result))
        {
            Console.WriteLine(result);
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
