    [AcceptVerbs("POST")]
    public async Task AddFile()
    {
        if (!Request.Content.IsMimeMultipartContent("form-data"))
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }            
        var streamProvider = new MultipartFormDataMemoryStreamProvider();
        await Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
        {
            ....
        });
    }
