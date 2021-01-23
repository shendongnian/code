    [WebMethod]
    [ScriptMethod(UseHttpGet = true)]
    public HttpResponseMessage GetGameData(string gameName)
    {
        // Get data 
        List<Int32> myList = new List<Int32>();
    
        // ...
        // Convert myList to JSON or XML string
        // Example of simple JSON conversion for your case / better to use converter
        var json = string.Format("[{0}]", myList.Select(x=>x.ToString()).Aggregate((x,y) => x + ", " + y));
        
        // Create response
        var httpResponseMessage = new HttpResponseMessage();
        // Set content
        httpResponseMessage.Content = json;
        // Set headers content type
        httpResponseMessage.Content.Headers.ContentType =  = new MediaTypeHeaderValue("application/json"); // or "application/xml"
        // Set status
        httpResponseMessage.StatusCode = HttpStatusCode.OK;
        return httpResponseMessage;
    }
