        public override void Init()
        {
            this.PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }
        void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);                    
                    Context.User = Thread.CurrentPrincipal = new CustomPricipal(authTicket.Name);
                }
            }
        }
