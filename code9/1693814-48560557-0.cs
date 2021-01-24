    try {
         // Webclient that raise 4XX
    }
    catch (WebException webex) 
    {
       using (var streamReader = new new StreamReader(webex.Response.GetResponseStream())) { 
        var domContent = streamReader.ReadToEnd();
       } 
    }
    
    
