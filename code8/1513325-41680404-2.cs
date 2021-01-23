    public class ProxyHandler : DelegatingHandler
    {
        private static HttpClient client = new HttpClient();
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // strip the /proxy portion of the path when making the request
            // to the backend node because our server will be made to listen
            // to :80/proxy/*   (see below when registering the /proxy route)
            var forwardUri = new UriBuilder(request.RequestUri.AbsoluteUri.Replace("/proxy", string.Empty));
            // replace the port from 80 to the backend target port
            forwardUri.Port = 8664;
            request.RequestUri = forwardUri.Uri;
            if (request.Method == HttpMethod.Get)
            {
                request.Content = null;
            }
            // replace the Host header when making the request to the 
            // backend node
            request.Headers.Host = "localhost:8664";
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            return response;
        }
    }
