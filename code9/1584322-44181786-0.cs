        public string Url { get; set; }
        public Stream RequestStream { get; set; }
    }
    
    public object Any(Proxy request)
    {
        if (string.IsNullOrEmpty(request.Url))
            throw new ArgumentNullException("Url");
    
        var hasRequestBody = base.Request.Verb.HasRequestBody();
        try
        {
            var bytes = request.Url.SendBytesToUrl(
              method: base.Request.Verb,
              requestBody: hasRequestBody ? request.RequestStream.ReadFully() : null,
              contentType: hasRequestBody ? base.Request.ContentType : null,
              accept: ((IHttpRequest)base.Request).Accept,
              requestFilter: req => req.UserAgent = "Gistlyn",
              responseFilter: res => base.Request.ResponseContentType = res.ContentType);
    
            return bytes;
        }
        catch (WebException webEx)
        {
            var errorResponse = (HttpWebResponse)webEx.Response;
            base.Response.StatusCode = (int)errorResponse.StatusCode;
            base.Response.StatusDescription = errorResponse.StatusDescription;
            var bytes = errorResponse.GetResponseStream().ReadFully();
            return bytes;
        }
    }
