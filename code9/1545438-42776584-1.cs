    [HttpGet]
    [Route("GenerateReport")]
    public HttpResponseMessage GenerateReport()
    {
        byte[] bytes = Generate();
                    
        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        var stream = new MemoryStream(bytes);
        result.Content = new StreamContent(stream);
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        {
            FileName = "test.pdf"
        };
    
        return result;
    }
