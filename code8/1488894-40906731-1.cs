    public class ApiController : Controller
    {
        [Route("api/test")]
        [HttpGet]
        public string GetData(string key, [FromQuery] string action, long id)
        {
            return $"{key} {action} {id}";
        }
    }
