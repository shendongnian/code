    public class SomeController : ApiController {
        // maps to GET /api/Some
        public HttpResponseMessage Get() {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        // maps to POST /api/Some
        public HttpResponseMessage Post() {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
