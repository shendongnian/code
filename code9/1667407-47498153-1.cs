    HttpWebRequest httpRequest  = WebRequest.CreateHttp("Login Url");
    httpRequest.Method = WebRequestMethods.Http.Post;
    httpRequest.ContentType = "*The content type, if necessary*";
    httpRequest.ContentLength = [Data].Length;
    
    // Other Headers configuration if needed
    
    using (Stream _stream = httpRequest.GetRequestStream())
    {
       _stream.Write([Data], 0, [Data].Length);
    }
    
    using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
    {
          // Get the response from the server
    }
