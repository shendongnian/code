    private void ExpireAllCookies()
    {
        if (HttpContext.Current != null)
        {
            int cookieCount = HttpContext.Current.Request.Cookies.Count;
            for (var i = 0; i < cookieCount; i++)
            {
                var cookie = HttpContext.Current.Request.Cookies[i];
                if (cookie != null)
                {
                    var cookieName = cookie.Name;
                    var expiredCookie = new HttpCookie(cookieName) {Expires = DateTime.Now.AddDays(-1)};
                    HttpContext.Current.Response.Cookies.Add(expiredCookie); // overwrite it
                }
            }
            // clear cookies server side
            HttpContext.Current.Request.Cookies.Clear();
        }
    }
