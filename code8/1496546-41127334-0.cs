    public class HomeController: Controller 
    {
        private IMemoryCache _cache;
        public HomeController(IMemoryCache cache) 
        {
            _cache = cache;
        }
    }
