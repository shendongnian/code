    public class CompaniesController : ApiController {
        // GET api/<controller>
        public HttpResponseMessage Get() {
            var collection = new Dictionary<string, object>();
            collection.Add("Microsoft", "microsoft.com");
            collection.Add("Google", "google.com");
            collection.Add("Facebook", "facebook.com");
            return Request.CreateResponse(HttpStatusCode.OK, collection, "application/json");
        }
    }
