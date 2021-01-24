    IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest; 
    WebHeaderCollection headers = request.Headers; 
    Console.WriteLine(request.Method + " " + request.UriTemplateMatch.RequestUri.AbsolutePath); 
    
    foreach (string headerName in headers.AllKeys)
    { 
        Console.WriteLine(headerName + ": " + headers[headerName]); 
    }
