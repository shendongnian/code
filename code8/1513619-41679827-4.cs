    // GET api/test/getTest
    [HttpGet]
    [Route("getTest")]
    public GetTestByIdQueryResult GetTest([FromServices]IGetTestByIdQueryHandler handler, GetTestByIdQuery query) {
        return handler.Retrieve(query);   
    }
