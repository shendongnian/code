    [HttpPost]
    [Route("rest/myMethod")]
    public IHttpActionResult MyMethod(MyViewModel model)
    {
        return Ok();
    }
