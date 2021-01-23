        private void GetUser()
        {
            string user = string.Empty;
            
            // if we have an http context, lets try it first
            if (System.Web.HttpContext.Current != null)
            {
                if (System.Web.HttpContext.Current.User.Identity != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                    user = System.Web.HttpContext.Current.User.Identity.Name;
            }
            if (user == null)
                user = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            _loggedOnUser = this.Users.SingleOrDefault(x => x.Username == user);
        }
