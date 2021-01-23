    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private ApplicationDbContext context = new ApplicationDbContext(); // your identity db context
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var roles = this.Roles.Split(',');
            string usr = httpContext.User.Identity.Name;
            bool authorize = false;
            if (usr != "")
            {
                foreach (var role in roles)
                {
                    var rs = context.Roles.Where(x => x.Name == role).SingleOrDefault().Id;
                    var userId = context.Users.Where(item => item.UserName == usr).SingleOrDefault().Id;
                    var test = context.Roles.Where(u => u.Users.Any(r => r.UserId == userId)).ToList();
                    foreach (var t in test)
                    {
                        if (t.Name == role)
                        {
                            authorize = true;
                            break;
                        }
                    }
                    if (authorize == true)
                    { break; }
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {   
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                // redirect to anywhere
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
