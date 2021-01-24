        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var routes = filterContext.RouteData.Values;
            string culture = (routes["culture"] ?? defaultCulture).ToString();
           
            if (!filterContext.HttpContext.Request.Cookies.AllKeys.Contains("culture"))
            {
                HttpCookie StudentCookies = new HttpCookie("culture");
                StudentCookies.Value = culture;
                StudentCookies.Expires = DateTime.Now.AddYears(1);
                filterContext.HttpContext.Response.Cookies.Add(StudentCookies);
            }
            else
            {
                if (filterContext.HttpContext.Request.Cookies["culture"].Value != (routes["culture"] ?? "").ToString() && routes["culture"] != null)
                {
                    filterContext.HttpContext.Response.Cookies["culture"].Value = (routes["culture"] ?? "").ToString();
                }
                if (routes["culture"] == null || routes["culture"] == UrlParameter.Optional)
                {
                    culture = filterContext.HttpContext.Request.Cookies["culture"].Value;
                }
            }
            HelperClass.SetCulture(culture);
            if (!routes.ContainsKey("culture") || routes["culture"] == UrlParameter.Optional)
            {
                filterContext.Result = new RedirectResult("/" + culture + "/" + filterContext.HttpContext.Request.Url.LocalPath);
            }
            CultureInfo info = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = info;
            Thread.CurrentThread.CurrentUICulture = info;
            return;
        }
