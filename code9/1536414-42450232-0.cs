    public class Foobar: IFoobar
    {
        public FooBar(IBar bar)
        {
            // using a guard clause ensures your dependency can
            // never be null.
            if (bar == null)
                throw new ArgumentNullException("bar");
            this.Bar = bar;
        }
        public virtual string Foo { get; set; }
        public virtual IBar Bar { get; private set; }
    }
