	public class HomeController : Controller
	{
		private IMemoryCache _cache;
		public HomeController(IMemoryCache memoryCache)
		{
			_cache = memoryCache;
		}
        public IActionResult Index()
        {
            string companyName = _cache[CacheKeys.CompanyName] as string;
            return View();
        }
