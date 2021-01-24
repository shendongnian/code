    public async Task<HttpResponseMessage> PostByteArrayAsync()
    {
           string root = HttpContext.Current.Server.MapPath("~/folder");
           var provider = new MultipartFormDataStreamProvider(root);
           await Request.Content.ReadAsMultipartAsync(provider);
           foreach (var file in provider.FileData)
           {
                 var buffer = File.ReadAllBytes(file.LocalFileName);
                 // store to db and other stuff
           }
           return Ok();
    }
