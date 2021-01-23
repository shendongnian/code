        public class HomeController : Controller
        {
            public async Task<IActionResult> Index(int? id, string subdomain)
            {
                 if (!string.IsNullOrWhiteSpace(subdomain))
                 {
                    if(subdomain=="admin")
                    return View("~/wwwrootadmin/index.cshtml");
                 }
                 return View("~/wwwroot/index.cshtml");
            }
        }
