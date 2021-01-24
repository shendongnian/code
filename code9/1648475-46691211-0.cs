    [Route("api/templates")]
    public class TemplatesController : Controller
    {
        [HttpGet]
        public IActionResult Get(int? id = null, string name = null, string type = null)
        {
            // now handle you db stuff, you can check if your id, name, type is null and handle the query accordingly
            return Ok(queryResult);
        }
    }
        
