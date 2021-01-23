        public static int TicketVersion { get { return 4; } }
        public static FormsAuthenticationTicket Ticket
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    FormsIdentity _formsIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
                    if (TicketVersion != _formsIdentity.Ticket.Version)
                    {
                        HttpContext.Current.Response.Redirect("~/SignOut.aspx");
                    }
                    return _formsIdentity.Ticket;
                }
                return null;
            }
        }
        public static string UserData
        {
            get
            {
                if (Ticket.IsNotNull())
                {
                    return Ticket.UserData;
                }
                else
                {
                    return null;
                }
            }
        }
     public static void AddCookies()
     {
     FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(TicketVersion,
                                                                                name,
                                                                                DateTime.Now,
                                                                                DateTime.Now.AddDays(10),
                                                                                true,
                                                                                _userData);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            authCookie.Expires = DateTime.Now.AddDays(10);
            HttpContext.Current.Response.Cookies.Add(authCookie);
     }
