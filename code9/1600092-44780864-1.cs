     public class BaseApiController : ApiController
      {
        public HttpResponseMessage Options()
        {
          return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
      }
