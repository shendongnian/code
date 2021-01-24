    public class MyController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Submit([FromForm] MyModel model)
        {
            //...
        }
    }
