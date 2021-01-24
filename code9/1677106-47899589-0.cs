    public HttpCookie Encrypt(string id)
    { 
        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "someName", DateTime.Now, DateTime.Now.AddHours(3), false, id, FormsAuthentication.FormsCookiePath);
        HttpCookie c = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
        return c;
    }
