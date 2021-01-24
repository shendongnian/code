    private readonly IMasterRepository _repository;
    public SomeController(IEnumerable<IMasterRepository> repositories)
    {
        _repository = repositories.First();  // (using System.Linq)
    }
