    [HttpGet]
    [Route("Cats/{catId:int}")]
    public IHttpActionResult GetByCatId(int catId)
    
    [HttpGet]
    [Route("Cats/{name}")]
    public IHttpActionResult GetByName(string name)
