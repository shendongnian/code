    public class FooService: IFooService
    {
        private readonly IRepository<Foo> _repository;
        public FooService(IRepository<Foo> repository)
        {
            this._repository = repository;
        }
        // ...
    }
