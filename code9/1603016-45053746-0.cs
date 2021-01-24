    [Route(""), HttpGet]
    public IHttpActionResult  Get(ODataQueryOptions<Poco.Language> queryOptions)
    {          
        return Ok(queryOptions.ApplyTo(_repository.GetAll().AsQueryable()));
    }
