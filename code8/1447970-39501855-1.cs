     public class YourController : Controller
        {
            public ICookieManager CookieManager { get; set; }
    
            public YourController()
            {
                CookieManager = new CookieManager();
            }
    
            public YourController(ICookieManager cookieManager)
            {
                CookieManager = cookieManager;
            }
    
            public ActionResult Login(LogInRequest logInRequest)
            {
                if (ModelState.IsValid)
                {
                    CookieManager.CreateUserCookie(logInRequest.UserName, logInRequest.Password, Response);
                    return RedirectToAction("search", "LoanDriver");
                }
            }
           
    
        }
