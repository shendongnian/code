    protected IHttpActionResult ParseValidatedResult<TApiModel>(ValidatedResult<TApiModel> apiResult) where TApiModel : class
    {
        if (apiResult == null)
        {
            return NotFound();
        }
        if (apiResult.Success)
        {
            return Ok(apiResult.Result);
        }
        if (!apiResult.Success && apiResult.FailureReason == ValidationFailureReason.Unauthorized)
        {
            return StatusCode(HttpStatusCode.Forbidden);
        }
        return BadRequest(string.Join("\n", apiResult.Errors));
    }
