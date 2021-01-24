    // setup an listener
    using(var listener = new HttpListener())
    {
        // on port 8080
    	listener.Prefixes.Add("http://+:8080/");
    	listener.Start();
    	while(true) 
    	{
    	    // wait for a connect
    		var ctx = listener.GetContext();
    		var req = ctx.Request;
    	    var resp = ctx.Response;
    		// default page 
    		var cnt = "<html><body><a href=\"/?site=http://linkedin.com\">click me</a> </body></html>";
    		foreach(var key in req.QueryString.Keys)
    		{
    		  if (key!=null) 
    		  {
    		     // if the url contains ?site=some url to an site
    			switch(key.ToString()) 
    			{
    				case "site":
    				// lets download
    				var wc = new WebClient();
    				// store html in cnt
    				cnt = wc.DownloadString(req.QueryString[key.ToString()]);
                    // when needed you can do caching or processing here
                    // of the results, depending on your needs
    				break;
    				default:
    				break;
    			}
    		  }
    		}
    		// output whatever is in cnt to the calling browser
    		var sr = new StringReader(cnt);
    		using(var sw = new StreamWriter(resp.OutputStream))
    		{
    			sw.Write(cnt);
    		}
    	}
    }
