    public HttpResponseMessage Get()
    {
    return new HttpResponseMessage()
    {
        Content = new StringContent(
            "<strong>test</strong>", 
            Encoding.UTF8, 
            "text/html"
        )
    };
    }
