    var WebClient = new PreAuthWebClient();
    WebClient.Credentials = new NetworkCredential("user", "pass","domain");
    //Do your GETs 
    Public class PreAuthWebClient: WebClient
    {
        protected override WebRequest GetWebRequest (Uri address)
        {
            WebRequest request = (WebRequest) base.GetWebRequest (address);
            request.PreAuthenticate = true;
            return request;
      }
    }
