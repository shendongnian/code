    [HttpPost]
    public async Task<IHttpActionResult> Post() {
        var content = Request.Content;
        //get file name from content disposition
        var fileName = content.Headers.ContentDisposition.FileName;
        //Get file stream from the request content
        var fileStream = await content.ReadAsStreamAsync();
        //...other code removed for brevity
        return Ok();
    }
