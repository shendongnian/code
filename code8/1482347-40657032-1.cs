    public ActionResult Index()
        {
            string cultureName = GetCultureCookieValue(this.ControllerContext.HttpContext.ApplicationInstance.Context);
                // Modify current thread's cultures            
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
          // ...
       }
    public static String GetCultureCookieValue(HttpContext httpContext)
        {
            HttpCookie cultureCookie = httpContext.Request.Cookies["_Culture"];
            if (cultureCookie != null)
            {
                return CultureHelper.GetImplementedCulture(cultureCookie.Value);
            }
            else
            {
                return CultureHelper.GetImplementedCulture(httpContext.Request.UserLanguages[0]); // obtain it from HTTP header AcceptLanguages
            }
        }
