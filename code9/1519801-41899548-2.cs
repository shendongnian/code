     public class HomeController : Controller
    {
        private AppSettings _AppSettings;
        public HomeController(IOptions<AppSettings> settings)
        {
            _AppSettings = settings.Value;
        }
