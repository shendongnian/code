    [HttpGet]
    [Route("GetTotalUsersData")]
    public async Task<IHttpActionResult> GetTotalUsersData(int schoolID) {
        var result = await _analytics.GetTotalUsersData(schoolID);
        if(result != null)
            return Ok(result);
        return NotFound();
    }
