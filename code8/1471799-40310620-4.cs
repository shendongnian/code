    public class IHttpActionResult<T> : System.Web.Http.IHttpActionResult
    {
        HttpConfiguration _configuration;
        T _content;
        HttpStatusCode _statusCode;
        HttpRequestMessage _request;
        public IHttpActionResult(T content, HttpStatusCode statusCode, HttpRequestMessage request, HttpConfiguration configuration)
        {
            _content = content;
            _request = request;
            _configuration = configuration;
            _statusCode = statusCode;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(_statusCode)
            {
                Content = new ObjectContent<dynamic>(_content, _configuration.Formatters.JsonFormatter),
                RequestMessage = _request,
                ReasonPhrase = "some phrase"
            };
            return Task.FromResult(response);
        }
    }
