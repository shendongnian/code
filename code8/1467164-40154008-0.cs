    public class ForbiddenResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly string _reason;
        public ForbiddenResult(HttpRequestMessage request,string reason)
        {
            _request = request;
            _reason = reason;
        }
        public ForbiddenResult(HttpRequestMessage request)
        {
            _request = request;
            _reason = "Forbidden";
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(HttpStatusCode.Forbidden,_reason);
            return Task.FromResult(response);
        }
    }
