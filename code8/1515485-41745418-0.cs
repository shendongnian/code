    [HttpGet]
    [AllowAnonymous]
    [Route("route")]
    public HttpResponseMessage GetByToken([FromUri] string path)
    {
        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        result.Content = new StreamContent(new FileStream(path, FileMode.Open, FileAccess.Read));
        string fileName = Path.GetFileNameWithoutExtension(path);
        string disposition = "attachment";
        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue(disposition) { FileName = fileName + Path.GetExtension(absolutePath) };
        result.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(Path.GetExtension(path)));
        return result;
    }
