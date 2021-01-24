    [RoutePrefix("api")]
    public class SomeController: ApiController
    {
        [Route("some")]
        [HttpGet]
        public HttpResponseMessage GetSome(HttpRequestMessage request)
        {
        ...
        }
    }
