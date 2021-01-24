    public async Task<IHttpActionResult> Post() {
        var request = this.Request;
        Trace.WriteLine(request.Content.Headers.ContentType.MediaType);  // "image/jpeg"
    
        var imageStream = await request.Content.ReadAsStreamAsync();
        //...save stream to disk or database...etc.    
        return Ok("Worked");
    }
