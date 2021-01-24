     public static void RemoveCookie(string cookieName)
        {
            if (HttpContext.Current.Response.Cookies[cookieName] != null)
            {
                HttpContext.Current.Response.Cookies[cookieName].Value = null;
                HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Now.AddMonths(-1);
            }
        }
