    [HttpPost("api/v1/testGetAll")]
    public IHttpActionResult Test([FromBody]object filteringOptions)
    {
    	return Ok(myService.GetLogs(filteringOptions).ToArray());
    }
