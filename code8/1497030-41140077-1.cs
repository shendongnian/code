    private sealed class AutofacUnitOfWork : IUnitOfWork
    {
        private readonly IComponentContext _container;
        public AutofacUnitOfWork(IComponentContext container)
        {
            this._container = container;
        }
        
        public IRepository<TModel> Repository<TModel>()
        {
            return _container.Resolve<IRepository<TModel>>();
        }
    }
