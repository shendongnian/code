    [HttpGet]
    public HttpResponseMessage Generate()
    {
       
         var stream = new FileStream("C:\\inetpub\\wwwroot\\Projects\\Attachments\\Invoice_2424.pdf", FileMode.Open);
    
        var result = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new ByteArrayContent(stream.ToArray())
        };
        result.Content.Headers.ContentDisposition =
            new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        {
            FileName = "fileName.pdf"
        };
        result.Content.Headers.ContentType =
            new MediaTypeHeaderValue("application/octet-stream");
    
        return result;
    }
