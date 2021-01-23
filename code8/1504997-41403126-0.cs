        public class HomeController : Controller
        {
          public string GetHeaderValue([FromHeader(Name = "Accept")] string acceptedFormat)
          {
            return acceptedFormat;
            return null;
          }
        }
