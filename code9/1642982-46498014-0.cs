    public IHttpActionResult Get( ODataQueryOptions<YourEntityType> queryOptions )
    {
        // base query with ODataQueryOptions applied
        var query = queryOptions.ApplyTo( dataServcie.GetAll() ) 
            as IQueryable<YourEntityType>;
        // get distinct TestResultTypeId's and then count
        var count = query.Select(x => x.TestResultTypeId)
                .Distinct()
                .Count();
        return Ok( count );
    }
