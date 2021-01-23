    public static class LocalVideoServer 
    {
        const string baseurl = @"http://localhost:50505/{0:N}/";
    
        static string url;
        
        // returns an url for a resource for the current running server
        public static string GetUrlForResource(string resource) {
          return url + resource;
        }
        
        static LocalVideoServer() {
            var http = new HttpListener();
            // clean up when we exit
            AppDomain.CurrentDomain.ProcessExit += (s,e) => {http.Abort();};
            // what url are we going to serve on
            // this url will be different of each run
            url = String.Format(baseurl, Guid.NewGuid());
            http.Prefixes.Add(url);
            // start handling local http requests
            http.Start();
            http.BeginGetContext(ContextCallBack, http);
        }
        
        // gets a specific resource based on the id
        static Stream GetResource(string id) 
        {
           Stream resource = null;
           if (id == "_64") {
             // get stream from embedded resource
             resource = new MemoryStream(Offline_Video_Management.Properties.Resources._64);
            } 
            else 
            {
               // some other (file) resource
               resource = File.Open(@"C:\what\ever\path\suits\here" + id, FileMode.Open);
            }
            return resource;
        }
        
        // server http requests
        static void ContextCallBack(IAsyncResult result)
        {
            var listener = (HttpListener) result.AsyncState;
            http.BeginGetContext(ContextCallBack, listener); // listen for the next connection
            
            var ctx = listener.EndGetContext(result);
            
            var requestUrl = ctx.Request.Url.ToString(); // the url 
            var resource = requestUrl.Substring(requestUrl.LastIndexOf('/') + 1); // find the "id"
            
            ctx.Response.ContentType="video/mp4"; // assume we always return an mp4 video
            ctx.Response.StatusCode = 200;  // success
            
            using(var stream = GetResource(resource)) // we want to close resources
            {
                stream.CopyTo(ctx.Response.OutputStream); // send the resource as is to Windows Media Player
            }
        }
    }
