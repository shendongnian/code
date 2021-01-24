        protected void Application_AuthenticateRequest(object sender, EventArgs e)
            {
    
                var app = (HttpApplication) sender;
                var ctx = app.Context;
                
                if (ctx.User != null)
                {
                    //Read the role from database                
                    using (var context = new BackendDbContext())
                    {
                        var user = context.Set<User>().Find(Convert.ToInt32(ctx.User.Identity.Name));
                        var identity = new GenericIdentity(user.UserId.ToString());
                        var proncipal = new GenericPrincipal(
                            identity,
                            new[] {user.UserRoleId.ToString()});
    
                        ctx.User = proncipal;
                    }
                }
             }
