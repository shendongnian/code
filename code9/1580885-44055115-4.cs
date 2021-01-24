    public class Bar : List<Foo>
    {
    }
    public class Foo
    {
        public string UserId { get; set; }
        public int OrderNumber { get; set; }
        public List<string> CustomerId { get; set; }
    }
