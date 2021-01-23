    [HttpGet]
    [Route("api/foos")]
    public async Task<IActionResult> Get()
    {
        IList<HttpStatusCode> statusCodes = await GetStatusCodes(_context.URLs.ToList());
        return this.Ok(statusCodes);
    }
