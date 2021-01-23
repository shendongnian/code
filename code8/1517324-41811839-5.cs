    [HttpGet]
    [Route("api/foos")]
    public async Task<IActionResult> Get()
    {
        var urls = _context.URLs.ToList();
        IList<HttpStatusCode> statusCodes = await GetStatusCodes(urls);
        return this.Ok(statusCodes);
    }
