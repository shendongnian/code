        private void GetUser()
        {            
            // if we have an http context, lets try it first
            if (System.Web.HttpContext.Current != null)
            {
                if (System.Web.HttpContext.Current.User.Identity != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                    _loggedOnUser = System.Web.HttpContext.Current.User.Identity.Name;
            }
            if (_loggedOnUser == null)
                _loggedOnUser = System.Threading.Thread.CurrentPrincipal.Identity.Name;
        }
