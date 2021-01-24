    /// <summary>
    /// Called when a new web socket connection has been established.
    /// </summary>
    /// <param name="webSocketContext">The web socket context.</param>
    public abstract void WebSocketContext(System.Web.WebSockets.AspNetWebSocketContext webSocketContext);
    /// <summary>
    /// Process request method.
    /// </summary>
    /// <param name="context">The current http context.</param>
    public void ProcessRequest(System.Web.HttpContext context)
    {
        HttpResponse response = null;
  
        // Get the request and response context.
        response = context.Response;
        // If the request is a web socket protocol
        if (context.IsWebSocketRequest)
        {
             // Process the request.
             ProcessWebSocketRequest(context);
        }
    }
    /// <summary>
    /// Process the request.
    /// </summary>
    /// <param name="httpContext">The http context.</param>
    private void ProcessWebSocketRequest(System.Web.HttpContext httpContext)
    {
         HttpResponse response = null;
         // Get the request and response context.
         response = httpContext.Response;
         // Process the request asynchronously.
         httpContext.AcceptWebSocketRequest(ProcessWebSocketRequestAsync);
    }
    /// <summary>
    /// Process the request asynchronously.
    /// </summary>
    /// <param name="webSocketContext">The web socket context.</param>
    /// <returns>The task to execute.</returns>
    private async Task ProcessWebSocketRequestAsync(System.Web.WebSockets.AspNetWebSocketContext webSocketContext)
    {
         await Nequeo.Threading.AsyncOperationResult<bool>.
             RunTask(() =>
             {
                 // Process the request.
                 WebSocketContext(webSocketContext);
             });
    }
