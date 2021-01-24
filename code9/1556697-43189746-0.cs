    [ResponseType(typeof(Media))]
    public async Task<IHttpActionResult> PostMedia() {
       
        var content = Request.Content as MultipartContent;
        if (content == null) {
            return BadRequest();
        }
        var parts = content.ToArray();
        var media = await parts[0].ReadAsAsync<Media>();
        var data = await parts[1].ReadAsByteArrayAsync();
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
