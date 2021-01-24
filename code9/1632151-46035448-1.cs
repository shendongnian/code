    public class ModelStateResult : InvalidModelStateResult
    {
        private readonly HttpStatusCode _status;
        public ModelStateResult(ModelStateDictionary modelState, ApiController controller, HttpStatusCode status) : base(modelState, controller)
        {
            _status = status;
        }
        public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = base.ExecuteAsync(cancellationToken).Result;
            response.StatusCode = _status;
            return Task.FromResult(response);
        }
    }
