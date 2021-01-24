    public class GzipClientFactory : Flurl.Http.Configuration.IHttpClientFactory
    {
    	public HttpMessageHandler CreateMessageHandler() => new HttpClientHandler()
    	{
    		AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
    	};
    
    	public HttpClient CreateHttpClient(HttpMessageHandler handler) => 
            new HttpClient(handler);
    }
