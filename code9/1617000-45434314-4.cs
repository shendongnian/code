    public interface IServiceFactory<T>
    {
        T Create(CountryCode countryCode);
    }
    public ActorExample(IServiceFactory<IServiceOne> factory)
    {
        this.factory = factory;
    }
    kernel.Register(Component.For(typeof(IServiceFactory<>)).AsFactory();
