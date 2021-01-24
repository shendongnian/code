    interface IProviderFactory
    {
        IProvider GetProvider();
    }
    class ProviderFactory : IProviderFactory
    {
        private readonly Object1 _object1;
        private readonly Object2 _object2;
        public ProviderFactory(Object1 object1, Object2 object2)
        {
            _object1 = object1; //injected
            _object2 = object2; //injected
        }
        public IProvider GetProvider()
        {
            if (*logic*)
            {
                return new Provider1(_object1, _object2);
            }
            else
            {
                return new Provider2(_object1, _object2);
            }
        }
    }
