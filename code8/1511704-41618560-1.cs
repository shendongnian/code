    class Foo
    {
        public Bar Bar { get; set; } = new Bar();
    }
    {
        var foo = new Foo
        {
            Bar = { Name = "abc" } // no error
        };
    }
