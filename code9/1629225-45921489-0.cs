    [HttpPost, Route("logo")]
    public async Task<IHttpActionResult> SaveAsync([FromBody]Logo model) {
        if(ModelState.IsValid) {
            FileUploadResultModel result = await _fileService.SaveAsync(model);
            return Ok(result);
        }
        return BadRequest();
    }
