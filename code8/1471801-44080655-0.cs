    public class ObjectResult : IHttpActionResult
    {
        object _value;
        HttpRequestMessage _request;
        public ObjectResult(object value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            if (_value == null)
                return Task.FromResult(_request.CreateResponse(HttpStatusCode.NotFound));
            var response = _request.CreateResponse(HttpStatusCode.OK, _value);
            return Task.FromResult(response);
        }
    }
       //create your method:
        public IHttpActionResult Get()
        {
            return new ObjectResult(repository.GetAll(), Request);
        }
