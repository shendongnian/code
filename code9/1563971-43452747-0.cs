    public class BaseApiController : ApiController
    {
        public IHttpActionResult Ok<T>(T content) => Ok<T>(content);
        public IHttpActionResult Ok() => Ok();
        public IHttpActionResult InternalServerError() => InternalServerError();
        public IHttpActionResult InternalServerError(Exception exception) => InternalServerError(exception);
        public IHttpActionResult BadRequest() => BadRequest();
        public IHttpActionResult BadRequest(ModelStateDictionary modelState) => BadRequest(modelState);
        public IHttpActionResult BadRequest(string message) => BadRequest(message);
        public IHttpActionResult Redirect(Uri location) => Redirect(location);
        public IHttpActionResult Redirect(string location) => Redirect(location);
    }
