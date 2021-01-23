    [ResponseType(typeof(IQueryable<Something>))]
    [System.Web.Http.HttpGet, System.Web.Http.Route("Something/{id:guid}/SomeFiltrableList")]
    public async Task<IQueryable<Something>> Get(Guid id, ODataQueryOptions options)
    {
        var someFiltrableList = await _repository.GetSomething(id);
        return options
                    .ApplyTo(someFiltrableList)
                    .Cast<Something>()
                    .AsQueryable();
    }
