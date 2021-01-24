    public static void Clear(string key)
    {
        var httpContext = new HttpContextWrapper(HttpContext.Current);
        _response = httpContext.Response;
    
        HttpCookie cookie = new HttpCookie(key) 
            { 
                Expires = DateTime.Now.AddDays(-1) // or any other time in the past
            };
        _response.Cookies.Set(cookie);
    }
