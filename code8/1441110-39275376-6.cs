    public class Baz
    {
        public String Name { get; set; }
    }
    public class Bar
    {
        public Foo Foo { get; } = new Foo();
        public Baz Baz { get; } = new Baz();
    }
