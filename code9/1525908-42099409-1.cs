    public class IntercepterMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
                //try to manipulate the request object
                 
            return base.SendAsync(request, cancellationToken);
        }
    }
