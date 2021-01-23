    public IEnumerable<ServiceModel> Get(
        Func<IEnumerable<ServiceModel>,  IEnumerable<ServiceModel>> transform)
    {
        IEnumerable<EntityModel> leftQuery = repository.GetAll;
        var outcomeBeforeMapping = transform(leftQuery);
        ...
    }
