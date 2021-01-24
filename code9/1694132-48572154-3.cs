    public void ProcessRequest(HttpContext context)
    {
        context.Response.Write("Hello World");
        context.Session["Heartbeat"] = DateTime.Now;
    }
