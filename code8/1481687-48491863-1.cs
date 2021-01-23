    public async Task<IHttpActionResult> UploadFile()
    {
        if (!Request.Content.IsMimeMultipartContent())
        {
            return StatusCode(HttpStatusCode.UnsupportedMediaType);
        }        
    
        var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
    
        foreach (var stream in filesReadToProvider.Contents)
        {
            // Getting of content as byte[], picture name and picture type
            var fileBytes = await stream.ReadAsByteArrayAsync();
            var pictureName = stream.Headers.ContentDisposition.FileName;
            var contentType = stream.Headers.ContentType.MediaType;
        }
    }
