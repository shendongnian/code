    [HttpGet]
    [Route("api/data/summary")]
    public async Task<IHttpActionResult> Get()
    {
        var result = await DataService.GetDataObjects().ConfigureAwait(false);
        return Ok(result);
    }
