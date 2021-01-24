    class AppleFactory : IAppleFactory
    {
        ...
    
        public IApple CreateApple(int size)
        {
            return _container.Resolve<IApple>(new ParameterOverrides<Apple> {{nameof(size), size}};
        }
    }
