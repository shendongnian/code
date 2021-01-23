    [HttpPost]
    [ReadableBodyStream]
    public string SomePostMethod()
    {
        using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
        {
            string body = stream.ReadToEnd();
            // body = "param=somevalue&param2=someothervalue"
        }
    }
