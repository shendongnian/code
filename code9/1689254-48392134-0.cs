    public class Foo
    {
        public Bar MyBar { get; set; }  
    }
    public class Bar
    {
        public Foo MyFoo { get; set; } 
    }
    public void CircularReferenceTest()
    {
        var foo = new Foo();
        var bar = new Bar();
 
        foo.MyBar = bar;
        bar.MyFoo = foo;
    }
