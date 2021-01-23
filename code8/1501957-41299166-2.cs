      FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
        username,
        DateTime.Now,
        DateTime.Now.AddMinutes(30),
        isPersistent,
        userData,
        FormsAuthentication.FormsCookiePath);
      // Encrypt the ticket.
      string encTicket = FormsAuthentication.Encrypt(ticket);
      // Create the cookie.
      Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
