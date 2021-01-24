    public class RestDbApiController : Controller
    {
        [HttpGet]
        [Route("api/{name}/[action]")]
        public virtual async Task<JsonResult> Get(string name, string apiKey = null) 
        {
            ...
        }
    }
