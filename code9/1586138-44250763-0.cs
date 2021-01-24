    public async Task<HttpListenerContext> GetContextAsync()
    {
        HttpListenerContext context = await listener.GetContextAsync();
        if (context.Request.IsWebSocketRequest)
        {
            return context;
        }
        else
        {
            context.Response.StatusCode = 500;
            context.Response.Close();
            return await GetContextAsync(); //not sure here
        }
    }
