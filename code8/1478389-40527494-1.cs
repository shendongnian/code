    [HttpGet]
    [Route("Cats/{catId:int}")]
    public IHttpActionResult GetByCatId(int catId)
    
    [HttpGet]
    [Route("Cats/{name:string}")]
    public IHttpActionResult GetByName(string name)
