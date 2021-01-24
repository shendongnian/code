    [Route("myaction")]
    [HttpGet] /* or other HttpVerb */
    public IHttpActionResult SomeMethod()
    {
       ...
    }
    [Route("myaction/{id}")]
    [HttpGet] /* or other HttpVerb */
    public IHttpActionResult SomeMethod(int id)
    {
       ...
    }
