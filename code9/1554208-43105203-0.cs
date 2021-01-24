    using (WebClient client = new WebClient()) {
         string data = client.DownloadString(builder.Uri);
    	 if (string.IsNullOrEmpty(data)) {
    	      return null;
    	 }
    
    	 var parsedQueryString = HttpUtility.ParseQueryString(data);
    	 return parsedQueryString["access_token"];
    }
