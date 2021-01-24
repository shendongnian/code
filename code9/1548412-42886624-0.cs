    [Route("StatusUpdate")]
    [HttpGet]
    public IHttpActionResult StatusUpdate() {
        return Ok(DateTime.Today);
    }
