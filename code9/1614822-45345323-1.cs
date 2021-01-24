    try
    {
         request = (HttpWebRequest)WebRequest.Create(new Uri(this._url, UriKind.Absolute));
         request.UserAgent = UserAgent.get_user_agent();
         noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
         request.CachePolicy = noCachePolicy;
                    
         (WebResponse response = request.GetResponse())
         {
              // Rest of your code inside here
         }
    }
