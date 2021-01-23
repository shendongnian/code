    class Field
    {
        public string Name { get; set; }
        public Object Value { get; set; }
    }
    var customFields = new Field[]
    {
        new Field { Name = "nickname ", Value = "Bob" },
        new Field { Name = "age", Value = 42 },
        new Field { Name = "customer_since", Value = new DateTime(2000, 12, 1) }
    };
