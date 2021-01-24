    public HttpResponseMessage Post([FromBody]string[] info)
    {
        // create your file on the fly.
        var txtBuilder = new StringBuilder();
        for(int n = 0; n <= str.Length; n = n + 2)
        {
            txtBuilder.AppendLine(str[n]);
        }
    
        // make it as a stream
        var txtContent = txtBuilder.ToString();
        var txtStream = new MemoryStream(Encoding.UTF8.GetBytes(txtContent));
    
        // create the response and returns it
        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        result.Content = new StreamContent(txtStream);
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        {
            FileName = info[0] // Not sure about that part. You can change to "text.txt" to try
        };
    
        return result;
    }
