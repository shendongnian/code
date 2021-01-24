    public class IntercepterMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
                //try to manipulate the reauest object
                 
            return base.SendAsync(request, cancellationToken);
        }
    }
