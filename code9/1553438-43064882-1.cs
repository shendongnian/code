    [Route("List")]
    [HttpGet]
    public IHttpActionResult List([FromUri(Name = "$filter")] string filter = null)
    {
        // ... code here ...
    
        return (Ok());
    }
