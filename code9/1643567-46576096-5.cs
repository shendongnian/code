    public class FooController : ApiController
    {
        [HttpGet]
        public void Bar([ValueProvider(typeof(ClaimsPrincipalValueProviderFactory))]ApiKey apiKey)
        {
            // ...
        }
    }
