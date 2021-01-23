    HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("SESSION");
                if (cookie != null)
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                    var userName = ticket.Name;
                    var userData = ticket.UserData.Split('/').ToArray();
    
                    string _User = userData[0];
                    string _Password = userData[1];
                    ... Your code to authenticate and 'Response.Redirect'...
                 }
