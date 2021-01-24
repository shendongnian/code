    public class MyController : Controller
    {
        private readonly IOptionsSnapshot<MySettings> _settings;
        
        public MyController(IOptionsSnapshot<MySettings> settings)
        {
            _settings = settings;
        }
        ...
    }
