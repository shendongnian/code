    class Example
    {
        private readonly IProviderFactory _providerFactory;
        public Example(IProviderFactory providerFactory)
        {
            _providerFactory = providerFactory;  //Injected
        }
        public void Test()
        {
            IProvider p = _providerFactory.GetProvider();
            p.DoSomething();
        }
    }
