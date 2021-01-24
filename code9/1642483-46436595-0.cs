    static void Main(string[] args)
    {
        var thing = new MyClass
        {
            Id = "ID",
            Description = "Description",
            Location = "Location",
            MyObjectLists = new List<MyObject>
            {
                new MyObject { Name = "Name1" },
                new MyObject { Name = "Name2" }
            }
        };
        var json = JsonConvert.SerializeObject(thing);
        Console.WriteLine(json);
        Console.Read();
    }
    class MyClass
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<MyObject> MyObjectLists { get; set; }
        public bool ShouldSerializeMyObjectLists()
        {
            return false;
        }
    }
    class MyObject
    {
        public string Name { get; set; }
    }
