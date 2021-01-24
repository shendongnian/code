    [HttpGet]
    [Route("testasync")]
    public async Task<IHttpActionResult> TestAsync()
    {
        try
        {
            return Ok( await _iKOTManager.TestAsync());
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            return null;
        }
    }
