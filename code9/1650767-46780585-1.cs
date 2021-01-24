    public static void CreateCookie(string Cookie)
    {
        HttpCookie cookie = new HttpCookie(Cookie);
        cookie.Expires = DateTime.Now.AddYears(1);
        HttpContext.Current.Response.Cookies.Add(cookie);   //<-- Add
    }
