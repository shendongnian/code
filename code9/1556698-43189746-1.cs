    [ResponseType(typeof(Media))]
    public async Task<IHttpActionResult> PostMedia() {
       
        if (!Request.Content.IsMimeMultipartContent()) { 
            return StatusCode(HttpStatusCode.UnsupportedMediaType); } 
        
        var filesReadToProvider = await Request.Content.ReadAsMultipartAsync(); 
        
        var media = await filesReadToProvider.Contents[0].ReadAsAsync<Media>(); 
        var data = await filesReadToProvider.Contents[1].ReadAsByteArrayAsync();
        int i = data.Length;
        if (!ModelState.IsValid) {
            return StatusCode(HttpStatusCode.ExpectationFailed);
        }
        if (MediaExists(media.MediaId))
            WebApplication1Context.db.Media.Remove(WebApplication1Context.db.Media.Where(p => p.MediaId == media.MediaId).ToArray()[0]);
        WebApplication1Context.db.Media.Add(media);
        try {
            WebApplication1Context.db.SaveChanges();
        } catch (DbUpdateException) {
            return StatusCode(HttpStatusCode.InternalServerError);
        }
        return Ok(media);
    }
