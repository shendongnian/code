    public class Foo
    {
        public string Bar {get;set;}
        public Foo(string bar)
        {
            Bar = bar;
        }
        public Foo Copy()
        {
            Foo aCopy = new Foo(this.Bar);
            return aCopy;
        }
    }
