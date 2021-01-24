    public class AuthorizationBatchHandler : DefaultHttpBatchHandler
    {
        public AuthorizationBatchHandler(HttpServer httpServer) : base(httpServer)
        {
        }
        public override async Task<IList<HttpRequestMessage>> ParseBatchRequestsAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requests = await base.ParseBatchRequestsAsync(request, cancellationToken);
            foreach (var childRequest in requests)
            {
                childRequest.Headers.Authorization = request.Headers.Authorization;
            }
            return requests;
        }
    }
