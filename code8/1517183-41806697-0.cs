    [HttpPost]
    [Route("api/upload")]
    public async Task<IHttpActionResult> Upload()
    {
        if (!Request.Content.IsMimeMultipartContent())
        {
            return this.StatusCode(HttpStatusCode.UnsupportedMediaType);
        }
        var filesProvider = await Request.Content.ReadAsMultipartAsync();
        var fileContents = filesProvider.Contents.FirstOrDefault();
        if (fileContents == null)
        {
            return this.BadRequest("Missing file");
        }
        byte[] payload = await fileContents.ReadAsByteArrayAsync();
        // TODO: do something with the payload.
        // note that this method is reading the uploaded file in memory
        // which might not be optimal for large files. If you just want to
        // save the file to disk or stream it to another system over HTTP
        // you should work directly with the fileContents.ReadAsStreamAsync() stream
        return this.Ok(new
        {
            Result = "file uploaded successfully",
        });
    }
