    public class ConvertGetToPostHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Add your logic here to decide if the request Method needs to be changed
            // Caution: This works only if you're redirecting internally
            request.Method = HttpMethod.Post;
            return await base.SendAsync(request, cancellationToken);
        }
    }
