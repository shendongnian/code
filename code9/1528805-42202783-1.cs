    [RoutePrefix("api/Default")]
    public class DefaultController : ApiController {
    
        [HttpGet]
        //GET api/Default
        //GET api/Default?name=John%20Doe 
        //GET api/Default/John%20Doe
        [Route("{name?}")]
        public string Get(string name = null) {
            return $"Hello " + name;
        }
    }
