        public class JsonWebCall<T>
    {
    	public static string baseURl = "http://YourServiceURL/";
    
    	 /// <summary>
    	 /// Gets the client.
    	 /// </summary>
    	 /// <returns></returns>
    	public static HttpClient GetClient()
    	{
    		var timeout = new TimeSpan(0, 10, 0);
    		var client = new HttpClient(new ModernHttpClient.NativeMessageHandler() );
    		// Due to a bug in Xamarin's HttpClient, this value MUST exceed the timeout of the native http client.  
    		// The REAL timeout will be the native http client's timeout which will properly throw the timeout exception.
    		client.Timeout = timeout.Add(new TimeSpan(0, 1, 0));
    		return client;
    	}
    
    	/// <summary>
    	/// Gets the message.
    	/// </summary>
    	/// <param name="method">The method.</param>
    	/// <param name="url">The URL.</param>
    	/// <param name="authkey">The authkey.</param>
    	/// <param name="Manufacturer">The manufacturer.</param>
    	/// <param name="Model">The model.</param>
    	/// <param name="OS">The os.</param>
    	/// <param name="OSVersion">The os version.</param>
    	/// <param name="UniqueIdentifier">The unique identifier.</param>
    	/// <param name="AppVersionandBuild">The application versionand build.</param>
    	/// <returns></returns>
    	public static HttpRequestMessage GetMessage(HttpMethod method, string url, string authkey, string Manufacturer, string Model, string OS, string OSVersion, string UniqueIdentifier, string AppVersionandBuild)
    	{
    		var message = new HttpRequestMessage(method, url);
    
    		if (!string.IsNullOrWhiteSpace(authkey))
    			message.Headers.Add("X-AUTH-KEY", new List<string>() { authkey });
    		if (!string.IsNullOrWhiteSpace(UniqueIdentifier))
    			message.Headers.Add("X-DEVICE-ID", new List<string>() { UniqueIdentifier });
    		if (!string.IsNullOrWhiteSpace(Model))
    			message.Headers.Add("X-DEVICE-MODEL", new List<string>() { Model });
    		if (!string.IsNullOrWhiteSpace(Manufacturer))
    			message.Headers.Add("X-DEVICE-MFG", new List<string>() { Manufacturer });
    		if (!string.IsNullOrWhiteSpace(OSVersion))
    			message.Headers.Add("X-OS-VERSION", new List<string>() { OSVersion });
    		if (!string.IsNullOrWhiteSpace(OS))
    			message.Headers.Add("X-OS-NAME", new List<string>() { OS });
    		if (!string.IsNullOrWhiteSpace(AppVersionandBuild))
    			message.Headers.Add("X-APP-VERSION", new List<string>() { AppVersionandBuild });
    		return message;
    	}
    	/// <summary>
    	/// Get data that is not encapulated in an odata call
    	/// </summary>
    	/// <param name="url">the url of the service action</param>
    	/// <param name="authkey">The authentication key required y the server</param>
    	/// <param name="DeviceID">the device id of the device making this service call</param>
    	/// <returns></returns>
    	public async static Task<Tuple<T>> Get(string url, string authKey, string Manufacturer, string Model, string OS, string OSVersion, string UniqueIdentifier, string AppVersionandBuild)
    	{
    		var client = GetClient();
    		var req = GetMessage(HttpMethod.Get, url, authKey, Manufacturer, Model, OS, OSVersion, UniqueIdentifier, AppVersionandBuild);
    		var response = await client.SendAsync(req).ConfigureAwait(false);
    		T returnedObject = default(T);
    		returnedObject = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
    
    		return new Tuple<T>(returnedObject);
    	}
    	/// <summary>
    	/// Gets the request.
    	/// </summary>
    	/// <param name="method">The method.</param>
    	/// <param name="url">The URL.</param>
    	/// <param name="authkey">The authkey.</param>
    	/// <param name="AppVersionandBuild">The application versionand build.</param>
    	/// <returns></returns>
    	public static HttpRequestMessage GetRequest(HttpMethod method, string url, string authkey, string AppVersionandBuild)
    	{
    		var message = new HttpRequestMessage(method, url);
    
    		if (!string.IsNullOrWhiteSpace(authkey))
    			message.Headers.Add("X-AUTH-KEY", new List<string>() { authkey });
    		if (!string.IsNullOrWhiteSpace(AppVersionandBuild))
    			message.Headers.Add("X-APP-VERSION", new List<string>() { AppVersionandBuild });
    		return message;
    	}
    
    	/// <summary>
    	/// Gets the direct.
    	/// </summary>
    	/// <param name="url">The URL.</param>
    	/// <param name="authKey">The authentication key.</param>
    	/// <param name="AppVersionandBuild">The application versionand build.</param>
    	/// <returns></returns>
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
    }
