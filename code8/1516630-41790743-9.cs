     public class HomeController : Controller
     {
        public _appsettings;
        public HomeController(IOptions<AppSettings> appSettings)
        {
           _appsettings = appSettings;
        }
     }
