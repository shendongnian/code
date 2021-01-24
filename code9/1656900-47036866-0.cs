    public class HomeController : Controller  
    {
        private MySettings _settings;
        public HomeController(IOptions<MySettings> settings)
        {
            _settings = settings.Value
            // _settings.StringSetting == "My Value";
        }
    }
