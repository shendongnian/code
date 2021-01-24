    [HttpPost, Route("logo")]
    public async Task<IHttpActionResult> SaveAsync([FromBody]Logo model) {
        if(ModelState.IsValid) {
            byte[] content = Convert.FromBase64String(model.Content);
            var id = model.Id;
            //...
            return Ok(result);
        }
        return BadRequest();
    }
