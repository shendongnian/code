    // read the cookie
    var legacyCookie = Request.Cookies["userInfo"].FromLegacyCookieString();
    var username = legacyCookie["userName"];
    // write the cookie
    var kvpCookie = new Dictionary<string, string>()
    {
        { "userName", "patrick" },
        { "lastVisit", DateTime.Now.ToString() }
    };
    Response.Cookies.Append("userInfo", kvpCookie.ToLegacyCookieString());
