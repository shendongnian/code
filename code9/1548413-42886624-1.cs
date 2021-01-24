    [Route("StatusUpdate")]
    [HttpGet]
    public IHttpActionResult StatusUpdate() {
        return Ok(new StatusUpdateResponse { Timestamp = DateTime.Today });
    }
