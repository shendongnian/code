    class Foo {
        public Int32 Count { get; set; }
        public FooValue[] Value { get; set; }
    }
    class FooValue {
        public Int32 Id { get; set; }
        public Guid ProjectId { get; set; }
        public String Name { get; set; }
    }
    Foo foo = JsonConvert.Deserialize<Foo>( jsonStr );
    return foo.Value[0].Id;
