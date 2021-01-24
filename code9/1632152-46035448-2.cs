    public class ModelStateResult : IHttpActionResult
    {
        public HttpStatusCode Status { get; }
        public ModelStateDictionary ModelState { get; }
        public HttpRequestMessage Request { get; }
        public ModelStateResult(HttpStatusCode status, ModelStateDictionary modelState, HttpRequestMessage request)
        {
            Status = status;
            ModelState = modelState;
            Request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = Request.CreateErrorResponse(Status, ModelState);
            return Task.FromResult(response);
        }
    }
