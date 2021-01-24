    public void SignIn(string username, bool createPersistentCookie)
    {
        var now = DateTime.UtcNow.ToLocalTime();
        TimeSpan expirationTimeSpan = FormsAuthentication.Timeout;
    
        var ticket = new FormsAuthenticationTicket(
            1 /*version*/,
            username,
            now,
            now.Add(expirationTimeSpan),
            createPersistentCookie,
            "" /*userData*/,
            FormsAuthentication.FormsCookiePath);
    
        var encryptedTicket = FormsAuthentication.Encrypt(ticket);
    
        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, 
            encryptedTicket)
        {
            HttpOnly = true,
            Secure = FormsAuthentication.RequireSSL,
            Path = FormsAuthentication.FormsCookiePath
        };
    
        if (ticket.IsPersistent)
        {
            cookie.Expires = ticket.Expiration;
        }
        if (FormsAuthentication.CookieDomain != null)
        {
            cookie.Domain = FormsAuthentication.CookieDomain;
        }
    
        Response.Cookies.Add(cookie);
    }
