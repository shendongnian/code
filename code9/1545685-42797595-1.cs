    /// <summary>
    /// The on web socket context event handler, triggered when a new connection is established or data is present. Should be used when implementing a new connection.
    /// </summary>
    public event Nequeo.Threading.EventHandler<System.Net.WebSockets.HttpListenerWebSocketContext> OnWebSocketContext;
    /// <summary>
    /// On http context action handler.
    /// </summary>
    /// <param name="context">The current http context.</param>
    private void OnHttpContextHandler(HttpListenerContext context)
    {
         HttpListenerRequest request = null;
         HttpListenerResponse response = null;
         // Get the request and response context.
         request = context.Request;
         response = context.Response;
         // If the request is a web socket protocol
         if (request.IsWebSocketRequest)
         {
              // Process the web socket request.
              ProcessWebSocketRequest(context);
         }
    }
    /// <summary>
    /// Process the web socket protocol request.
    /// </summary>
    /// <param name="context">The current http context.</param>
    private async void ProcessWebSocketRequest(HttpListenerContext context)
    {
         HttpListenerResponse response = null;
         // Get the request and response context.
         response = context.Response;
         // When calling `AcceptWebSocketAsync` the negotiated subprotocol 
         // must be specified. This sample assumes that no subprotocol  was requested. 
         HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(subProtocol: null);
                
         // Send the web socket to the handler.
         if (OnWebSocketContext != null)
              OnWebSocketContext(this, webSocketContext);
    }
