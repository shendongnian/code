    public class Baz : Foo
    {
        public DateTime BirthDate { get; set; }
        public Baz(Foo foo, DateTime birthDate) : base(foo) { BirthDate = birthDate; }
        public Baz(Baz baz) : base(baz) { BirthDate = baz.BirthDate; } // Allows further inheritance
    }
