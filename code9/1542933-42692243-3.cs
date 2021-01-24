    // Use the MobileAppController attribute for each ApiController you want to use  
    // from your mobile clients 
    [MobileAppController]
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            return "Hello World!";
        }
    }
