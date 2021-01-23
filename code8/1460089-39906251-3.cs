    public class HomeController : Controller
    {
        public HomeController(IOptions<MyConfiguration> config)
        {
            var someValue = config.Value.ValueOne; // "Some value"
        }
    }
