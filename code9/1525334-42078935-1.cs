    class Foo
    {
        public string someVariable;
        public string SomeProperty { get; }
    }
    var foo = new Foo();
    func(ref foo.someVariable, ""); //ok
    func(ref foo.SomeProperty, ""); //compile time error
