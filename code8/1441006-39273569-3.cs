    [WebMethod]
    [ScriptMethod(UseHttpGet = true)]
    public HttpResponseMessage GetGameData(string gameName)
    {
        // Get data 
        List<Int32> myList = new List<Int32>();
    
        // ...
        // Convert myList to XML or JSON string
        var convertedContent;
        
        // Create response
        var httpResponseMessage = new HttpResponseMessage();
        // Set content
        httpResponseMessage.Content = convertedContent;
        // Set headers content type
        httpResponseMessage.Content.Headers.ContentType =  = new MediaTypeHeaderValue("application/xml"); // or "application/json"
        // Set status
        httpResponseMessage.StatusCode = HttpStatusCode.OK;
        return httpResponseMessage;
    }
