    var request = WebRequest.Create(requestUri);
    
    request.ContentType = "application/json";
    request.Method = "GET";
    
    var type = request.GetType();
    var currentMethod = type.GetProperty("CurrentMethod", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(request);
    
    var methodType = currentMethod.GetType();
    methodType.GetField("ContentBodyNotAllowed", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(currentMethod, false);
    
    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
    {
    	streamWriter.Write("<Json string here>");
    }
    
    var response = (HttpWebResponse)request.GetResponse();
