    public static string baseURl = "http://YourServiceURL/";
        
        // Gets the client.
        public static HttpClient GetClient()
        {
        	var timeout = new TimeSpan(0, 10, 0);
        	var client = new HttpClient(new ModernHttpClient.NativeMessageHandler() );
        	// Due to a bug in Xamarin's HttpClient, this value MUST exceed the timeout of the native http client.  
        	// The REAL timeout will be the native http client's timeout which will properly throw the timeout exception.
        	client.Timeout = timeout.Add(new TimeSpan(0, 1, 0));
        	return client;
        }
        
        //Gets the Direct
        public async static Task<Tuple<T>> GetDirect(string url, string authKey, string AppVersionandBuild)
        {
        	var client = GetClient();
        	var req = GetRequest(HttpMethod.Get, url, authKey, AppVersionandBuild);
        	var response = await client.SendAsync(req).ConfigureAwait(false);
        	T returnedObject = default(T);
        	var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        	returnedObject = JsonConvert.DeserializeObject<T>(result);
        	return new Tuple<T>(returnedObject);
        }
