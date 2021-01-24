    // login etc
            if (chkRemember.Checked)
            {
                // calculate the total number of minutes in 20 days to use as the time out.
                int timeout = (int)TimeSpan.FromDays(30).TotalMinutes;
                // create an authentication ticket
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(txtUserName.Text, true, timeout);
                // Encrypt the ticket
                string encrptedTicked = FormsAuthentication.Encrypt(ticket);
                // create the cookie for the ticket, and put the ticket inside
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrptedTicked);
                // give cookie and ticket same expiration
                cookie.Expires = ticket.Expiration;
                // Attach cookie to current response. it will now to the client and then back to the webserver with every request
                HttpContext.Current.Response.Cookies.Set(cookie);
                // send the user to the originally requested page.
                string requestedPage = FormsAuthentication.GetRedirectUrl(txtUserName.Text, false);
                Response.Redirect(requestedPage, true);
            }
            else
            {
                // login without saving cookie to client
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
            }
