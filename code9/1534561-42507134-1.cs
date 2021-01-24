    // In some class that is ': ODataController'
    [EnableQuery] //Attribute makes sure the OData framework handles querying
    public IQueryable<TDto> Get(ODataQueryOptions<TDto> options) {
        //The names of the properties requested by the client in the '$expand=' query option
        string[] requestedExpands = Helpers.Expand.GetMembersToExpandNames(options); // I made a helper for this, you can probably just use your code
        var set = Db.Set<TEntity>().AsNoTracking(); //You might want to remove AsNoTracking if it doesn't work
        var converted = set.ProjectTo<TDto>(MapConfig, null, requestedExpands);
        return converted;
    }
