    // Version One
    public class ClassWithFactoryMethodOne
    {
        Func<IOne, ITwo, IApp> iAppFactory;
        public ClassWithFactoryMethodOne(Func<IOne, ITwo, IApp> iAppFactory)
        {
            this.iAppFactory = iAppFactory;
        }
        public IApp Create(IOne iOneInstance, ITwo iTwoInstance)
        {
            return this.iAppFactory(iOneInstance, iTwoInstance);
        }
    }
    // Version Two
    public class ClassWithFactoryMethodTwo
    {
        Func<string, string, IApp> iAppFactory;
        ClassWithFactoryMethodTwo(Func<string, string, IApp> iAppFactory)
        {
            this.iAppFactory = iAppFactory;
        }
        public IApp Create(string iOneNamedRegistration, string iTwoNamedRegistration)
        {
            return this.iAppFactory(iOneNamedRegistration, iTwoNamedRegistration);
        }
    }
