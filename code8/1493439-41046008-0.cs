    public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
    {
        ...
        var task = HandleRequestAsync(...);
        Task.Run(async () => { await task; }).GetAwaiter().GetResult();
        ...
    }
