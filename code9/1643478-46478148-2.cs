    public class GetTermsQuery {
        public string participantId { get; set; } 
        public string participantType { get; set; }
        public string programName { get; set; }
    }
    [Route("api/[controller]")]
    public class TermsController : Controller {    
        [HttpGet]  //GET api/terms?participantId=123&....
        public async Task<IActionResult> Get([FromQuery]GetTermsQuery model) {
            //...
        }
    }
