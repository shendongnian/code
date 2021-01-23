    public class MyModuleController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var content = "<html><body><h1>Hello World</h1><p>Some text</p></body></html>";
            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }
    }
