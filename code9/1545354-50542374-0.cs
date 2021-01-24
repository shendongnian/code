    [HttpGet("test")]
    public void Test()
    {
        Response.StatusCode = 200;
        Response.ContentType = "text/plain";
        using (Response.Body)
        {
            using (var sw = new StreamWriter(Response.Body))
            {
                sw.Write("Hi there!");
            }
        }
    }
