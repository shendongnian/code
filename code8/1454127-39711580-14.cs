    public class Foo : BaseFactory<Foo>
    {
        public bool IsCompleted { get; set; }
        public int Percentage { get; set; }
        public string Data { get; set; }
    }
    public class Bar : BaseFactory<Bar>
    {
        public string Username { get; set; }
    }
