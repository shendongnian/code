    public class TestController : ApiController
    {
        [Route("api/test/GetDetails/{language}")]
        public string GetDetails(string language)
        {
            // Use language string parameter here.
            return language;
        }
    }
