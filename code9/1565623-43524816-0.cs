    [Route("error")]
    public class ErrorController : Controller
    {
       [HttpGet("{status?}")]
       public IActionResult Index(int? status = null)
       {
            ViewBag.RequestId = HttpContext.TraceIdentifier;
            return this.View();
       }
    }
