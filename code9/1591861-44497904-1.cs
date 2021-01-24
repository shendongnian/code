    public class ReadRepositoryWrapper<T> : IReadRepositoryWrapper<T> where T : class
    {
      private readonly IFactory<IGenericReadRepository<T>> _factory;
      public ReadRepositoryWrapper(IFactory<IGenericReadRepository<T>> factory)
      {
        if(factory == null)
          throw new ArgumentNullException("factory");
        _factory = factory;
      }
      public IGenericReadRepository<T> GetReadRepository()
      {
        return _factory.Create();
      }
    }
