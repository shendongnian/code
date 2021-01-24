cs
    public IQueryable<dynamic> Get()
    {
        ... your code ...
        return queryOptions
            .ApplyTo(entities, new ODataQuerySettings
            {
                HandleNullPropagation = HandleNullPropagationOption.True
            })
            as IQueryable<dynamic>;
    }
