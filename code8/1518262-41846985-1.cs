    [Route("Test")]
    public class TestContoller : Controller
    {
        [HttpGet]
        [CheckHeaderFilter(HeaderOptions.RequestFor)]
        public IActionResult Index()
        {
            return Ok();
        }
    }
