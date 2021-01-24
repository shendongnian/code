    string contextTokenString = TokenHelper.GetContextTokenFromRequest(httpRequest);
    if (!string.IsNullOrEmpty(contextTokenString))
    {
        HttpCookie cookie = new HttpCookie("AppContextToken", contextTokenString);
        cookie.HttpOnly = true;
        Response.Cookies.Add(cookie);
    }
