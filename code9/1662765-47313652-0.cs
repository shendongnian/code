    [Route("applications")]
    public class ApplicationController
    {
        [HttpGet("{applicationId}")]
        public IActionResult Index(string applicationId)
        {
            // return your view
        }
    }
