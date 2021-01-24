    public class MyHttpMessageHandler : System.Net.Http.HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
        	HttpRequestMessage request,
	        CancellationToken cancellationToken)
        {
            //...(your implementation here)
        }
    }
