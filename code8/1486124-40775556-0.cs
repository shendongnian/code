    [HttpGet]
    public IHttpActionResult Get([FromUri]Query query) {
        var result = _queryDispatcher.Dispatch<Query, QueryResult>(query);
        return Ok(result);
    }
