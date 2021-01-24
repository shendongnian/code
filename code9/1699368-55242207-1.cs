    public class MyHttpClient {
	internal static HttpResult httpMethod( ... )
	{
		var _client = client();
		try
		{
			var message = new HttpRequestMessage( method, url );
			message.Content = new StringContent( content, Encoding.UTF8, "application/json" );
			var result = _client.SendAsync( message ).Result;// handle result
		}
		catch( Exception e ){}
	}
	private static HttpClient client()
	{
		var httpClientHandler = new HttpClientHandler() { Proxy = new MyProxy() };
		var httpClient = new MyClient( new Uri( "baseurl" ), httpClientHandler );
		return httpClient;
