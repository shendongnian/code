    [HttpGet]
    public ContentResult Get()
    {
        return new ContentResult {
            ContentType = "text/html",
            StatusCode = (int) HttpStatusCode.OK,
            Content = "<html><body>Welcome</body></html>"
        };
    }
