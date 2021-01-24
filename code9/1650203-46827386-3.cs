    public class TodoController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] Todo todo)
        {
            return Ok();
        }
    }
