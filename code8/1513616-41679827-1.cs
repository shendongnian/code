    // GET api/values/5
    [HttpGet]
    [Route("getTest")]
    public GetTestByIdQueryResult GetTest([FromServices]IQueryHandler<GetTestByIdQuery, GetTestByIdQueryResult> handler,GetTestByIdQuery query)
    {
        return handler.Retrieve(query);   
    }
