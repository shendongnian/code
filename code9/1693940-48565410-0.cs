    public abstract class FooBase
    {
    }
    
    public class Foo : FooBase
    {
    }
    
    public abstract class BarBase<F> where F : FooBase
    {
        public F Foo { get; set; }
    }
    
    public class Bar : BarBase<Foo>
    {
    }
