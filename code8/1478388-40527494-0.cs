    [HttpGet]
    [Route("Cats /{customerId:int}")]
    public IHttpActionResult GetByCatId(int catId)
    
    [HttpGet]
    [Route("Cats /{customerId:string}")]
    public IHttpActionResult GetByName(string name)
