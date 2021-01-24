    [RoutePrefix("api/{language}/test")]
    public class TestController : ApiController
    {
        [Route("GetDetails")]
        public string GetDetails(string language)
        {
            // Use language string parameter here.
            return language;
        }
    }
