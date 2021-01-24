    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
         [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(new List<object>()
            {
                new { id = 1, Name ="asd"},
                new { id = 2, Name ="dsa"}
            });
        }
    }
