    interface IFooFactory
    {
         IFoo Create();
         void Release(IFoo foo);
    }
    class FooFactory : IFooFactory
    {
        private readonly IBarService _barService;
        private readonly IQux qux;
        public FooFactory(IBarService barService, IQux qux)
        {
            _barService = barService;
            _qux = qux;
        }
        public IFoo Create()
        {
            return new Foo(_barService, _qux);
        }
        public void Release(IFoo foo)
        {
            // Handle both disposable and non-disposable IFoo implementations
            var disposable = foo as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
    class Foo : IFoo, IDisposable
    {
        public Foo(IBarService barService, IQux quxFactory)
        {
            _barService = barService;
            _qux = quxFactory;
        }
        public void Dispose()
        {
            _barService.Dispose();
            _qux.Dispose();
        }
    }
