    namespace WebApi {    
        [Route("api/[controller]")]
        public class Demo : Controller {    
            [HttpGet] // Matches 'GET /api/Demo'
            public string Ping() { 
                return "yo!"; 
            }
        }
    }
