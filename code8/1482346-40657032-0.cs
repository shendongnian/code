    public ActionResult SetCultureToNL()
        {
            SetCulture("nl-BE");
            return View("index");
        }
    private void SetCulture(String culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            if (httpContext.Request.Cookies["_Culture"] != null)
            {
                HttpCookie cultureCookie = new HttpCookie("_Culture", culture);
                
                httpContext.Response.SetCookie(cultureCookie);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("_Culture");
                cookie.Value = culture;
                
                httpContext.Response.Cookies.Add(cookie);
            }
        }
