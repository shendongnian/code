    [RoutePrefix("api/some")]
    public class SomeController: ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetSome(HttpRequestMessage request)
        {
        ...
        }
    }
