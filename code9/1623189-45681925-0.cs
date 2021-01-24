    [HttpGet("/GetbID/{bId})")
    [ResponseType(typeof(IEnumerable<A>))]
    public IHttpActionResult Get(int bId)
    [HttpGet("/GetListcId")]
    [ResponseType(typeof(IEnumerable<A>))]
    public IHttpActionResult Get(IList<int> cIds)
