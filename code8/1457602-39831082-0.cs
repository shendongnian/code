    string UserData = _User + "/" + _Password;
    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1 , _User , DateTime.Now, DateTime.Now.AddMinutes(60), _KeepLoggedIn, UserData);
    string encrypted = FormsAuthentication.Encrypt(ticket);
    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
    cookie.Name = "SESSION";
    
    Response.Cookies.Add(cookie);
