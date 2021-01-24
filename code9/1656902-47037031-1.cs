    public class HomeController : Controller  
    {
        private MySettings _settings;
        public HomeController(MySettings settings)
        {
            _settings = settings;
        }
    }
