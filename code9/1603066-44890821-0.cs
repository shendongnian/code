    interface IFoo
    {
        void SetBar(IBar bar);
    }
    class Foo : IFoo
    {
        private IBar _bar;
        public void SetBar(IBar bar)
        {
            _bar = bar;
        }
    }
    interface IBar
    {
        void SetFoo(IFoo foo);
    }
    class Bar : IBar
    {
        private IFoo _foo;
        public void SetFoo(IFoo foo)
        {
            _foo = foo;
        }
    }
    class MainClass
    {
        private IFoo _foo;
        private IBar _bar;
        public MainClass(IFoo foo, IBar bar)
        {
            _foo = foo;
            _bar = bar;
            _foo.SetBar(bar);
            _bar.SetFoo(foo);
        }
    }
    class Context // Here you build the structure you want
    {
        IFoo _foo;
        IBar _bar;
        MainClass _mainClass;
        public Context()
        {
            _foo = new Foo();
            _bar = new Bar();
            _mainClass = new MainClass(_foo, _bar);
        }
    }
