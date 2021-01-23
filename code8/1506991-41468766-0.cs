    public class FooXWrapper<T>: IFoo where T: FooX
    {
        readonly T foo;
        bool doCalled;
        public FooWrapper(T foo)
        {
            this.foo = foo;
        }
        public void Do()
        {
            doCalled = true;
        }
        public void Stuff()
        {
             if (!doCalled)
                 throw new InvalidOperationException("Must call Do");
             foo.DoStuff();
        }
    }
