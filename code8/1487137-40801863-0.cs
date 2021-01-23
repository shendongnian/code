    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, userName, DateTime.Now, DateTime.Now.AddDays(30), true, String.Empty);
    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
    HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
    authenticationCookie.Expires = ticket.Expiration;
    Response.Cookies.Add(authenticationCookie);
    
    FormsAuthentication.SetAuthCookie(userName, true);
