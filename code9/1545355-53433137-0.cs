    [HttpGet("test")]
    public ActionResult Test()
    {
        Response.StatusCode = 200;
        Response.ContentType = "text/plain";
        using (var sw = new StreamWriter(Response.Body))
        {
            sw.Write("something");
        }
        return null;
    }
