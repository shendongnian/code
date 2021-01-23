    public class Baz
    {
        public String Name { get; set; }
    }
    public class Bar
    {
        public Foo Foo { get; } = new Foo { 1000 };
        public Baz Baz { get; } = new Baz { Name = "Initial name" };
    }
