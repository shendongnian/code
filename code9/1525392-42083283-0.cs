    public void ProcessRequest(HttpContext context)
    {
        //image/png is png mime
        context.Response.ContentType = "image/png";
        //read buffer from database
        context.Response.BinaryWrite(buffer);
    }
