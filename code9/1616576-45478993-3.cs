    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    namespace WebApplication1.Controllers
    {
        public class HomeController : Controller
        {
            private readonly AppSettings _appSettings;
            public HomeController(IOptions<AppSettings> appSettings)
            {
                _appSettings = appSettings.Value;
            }
            public IActionResult Index()
            {
                var colour = _appSettings.Colour;
                return View();
            }
            public IActionResult Error()
            {
                return View();
            }
        }
    }
