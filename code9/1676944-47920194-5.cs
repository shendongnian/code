    public class SomeController : ApiController {
        // maps to GET /api/Some
        // note - no routing attributes anywhere
        public HttpResponseMessage Get() {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        // maps to POST /api/Some
        public HttpResponseMessage Post() {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
