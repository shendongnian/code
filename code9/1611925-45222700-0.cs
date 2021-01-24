    public class Foo
    {
        public int Id { get; set; }
        public Foo() {}
        public Foo(Foo foo) { Id = foo.Id; }
    }
    public class Bar : Foo
    {
        public string Name { get; set; }
        public Bar(Foo foo, string name) : base(foo) { Name = name; }
        public Bar(Bar bar) : base(bar) { Name = bar.Name; } // Allows further inheritance
    }
