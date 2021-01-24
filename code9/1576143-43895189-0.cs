    public HttpResponseMessage Get(string filename, string type)
    {
         MemoryStream stream = new MemoryStream(new AzureMainStorage("avideo").GetFile(filename));
    
         HttpResponseMessage partialResponse = Request.CreateResponse(HttpStatusCode.PartialContent);
         partialResponse.Content = new ByteRangeStreamContent(stream, Request.Headers.Range, "video/mp4");
         return partialResponse;  
    }
