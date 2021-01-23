    [HttpPut]
    [Route("v2/myaction/somethingelse")]
    public async Task<IHttpActionResult> MyAction([FromBody]jsonMessage message)
    {
        return Ok("Put ok");
    }
