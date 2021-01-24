    [HttpGet]
    [Route("testasync")]
    public async Task<IHttpActionResult> TestAsync() {
        return Ok(await _iKOTManager.TestAsync());
    }
