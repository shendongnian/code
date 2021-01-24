    class Example
    {
        private readonly IProviderFactory _providerFactory;
        public Example(IProviderFactory providerFactory)
        {
            _providerFactory = providerFactory;  //Injected
        }
        public void MainCode()
        {
            IProvider p = _providerFactory.GetProvider();
            var foo = p.GetDate();
        }
    }
