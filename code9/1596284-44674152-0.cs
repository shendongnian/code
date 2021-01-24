    public class SomeApiController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Test(Api.Test test)
        {
            var res = test.RecordsSubmissions;
            return StatusCode(HttpStatusCode.Created);
        }
        // Is equivalent of Test:
        [HttpPost]
        public void Test2(Api.Test test)
        {
            var res = test.RecordsSubmissions;
        }
    }
