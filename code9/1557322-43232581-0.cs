    public HttpResponseMessage Get()
    {
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        FileStream fileStream = File.OpenRead("FileName.pdf");
        response.Content = new StreamContent(fileStream);
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        return response;
    }
