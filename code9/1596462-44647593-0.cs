        class Class1
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        static void Main(string[] args)
        {
            var d = new Dictionary<string, Class1>();
            d.Add("Key1", new Class1() { id = "1", name = "one" });
            d.Add("Key2", new Class1() { id = "2", name = "two" });
            d.Add("CouldBeAnything", new Class1() { id = "n", name = "CouldBeAnything" });
            var json = JsonConvert.SerializeObject(d, Formatting.Indented);
        }
