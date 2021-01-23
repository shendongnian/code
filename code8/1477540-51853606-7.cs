    [HttpPost]
    [ReadableBodyStream]
    public string SomePostMethod()
    {
        //Note: if you're late and body has already been read, you may need this next line
        HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
        using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
        {
            string body = stream.ReadToEnd();
            // body = "param=somevalue&param2=someothervalue"
        }
    }
