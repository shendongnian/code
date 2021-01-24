        protected void Application_AuthenticateRequest(object sender, EventArgs e)
            {
    
                var app = (HttpApplication) sender;
                var ctx = app.Context;
                
                if (ctx.User != null)
                {
                    //Read the roles from database for current user, create a new Principal, attach the principal to the user (im using EF)               
                    using (var context = new BackendDbContext())
                    {
                        var user = context.Set<User>().Find(Convert.ToInt32(ctx.User.Identity.Name));
                        var identity = new GenericIdentity(user.UserId.ToString());
                        var principal = new GenericPrincipal(
                            identity,
                            new[] {user.UserRoleId.ToString()});
    
                        ctx.User = principal;
                    }
                }
             }
