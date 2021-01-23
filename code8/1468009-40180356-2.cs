    class Field
    {
        public string Name { get; set; }
    }
    class StringField : Field
    {
        public string Value { get; set; }
    }
    class IntField : Field
    {
        public int Value { get; set; }
    }
    class DateField : Field
    {
        public DateTime Value { get; set; }
    }
    var customFields = new Field[]
    {
        new StringField { Name = "nickname ", Value = "Bob" },
        new IntField { Name = "age", Value = 42 },
        new DateField { Name = "customer_since", Value = new DateTime(2000, 12, 1) }
    };
