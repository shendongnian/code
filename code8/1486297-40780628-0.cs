    public class MyModuleController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var content = "<html><body>Hello World</body></html>";
            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }
    }
