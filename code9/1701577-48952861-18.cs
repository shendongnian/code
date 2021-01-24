        httpContext.StreamWrite(httpContext.Response.Filter, html);
        // ...
        var module = new Module();
        module.PreRequestHandlerExecute(mockHttpContext.HttpContext());
    But `PreRequestHandlerExecute` sets `Response.Filter` with an instance of `ResponseSniffer`. So when `httpContext.StreamWrite` above it is called, `httpContext.Response.Filter` holds actually instance of `MemoryStream`, not `ResponseSniffer`. So the last fix you should make is to change the order of statements in UT body:
        // ...
        
        var module = new Module();
        module.PreRequestHandlerExecute(mockHttpContext.HttpContext());
        
        httpContext.ResponseWrite(html);
        httpContext.StreamWrite(httpContext.Response.Filter, html);
        module.ApplicationBeginRequest(mockHttpContext.HttpContext());
        module.ApplicationEndRequest(mockHttpContext.HttpContext());
        
        // ...
