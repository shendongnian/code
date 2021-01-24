    app.Use(async (http, next) =>
    {
        if (http.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await http.WebSockets.AcceptWebSocketAsync();
            var userName = HttpContext.Current.User.Identity.Name;
            WebSocketsSingleton.Instance.AddSocket(userName, webSocket);
            
            while(webSocket.State == WebSocketState.Open)
            {
                //waiting till it is not closed         
            }
			
			//removing this web socket from the collection
        }
    });
