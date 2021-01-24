    var handler = new WebRequestHandler();
    handler.UseDefaultCredentials = true;
    handler.AllowPipelining = true;
    handler.ServerCertificateValidationCallback =  (sender, cert, chain, error) => {
    	//do something with cert here
    	cert.Subject.Dump();
    	//useless validation on my part
        return true;
    };
    
    
    using (HttpClient client = new HttpClient(handler))
    {
      using (HttpResponseMessage response = await client.GetAsync("https://google.com"))
      {
        using (HttpContent content = response.Content)
        {
        	//foo
        }
      }
    }
