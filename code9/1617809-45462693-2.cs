    public class RestrictAccessToAdmins : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Do the default Authorise Logic (Check if user is loggedin) 
            base.AuthorizeCore(httpContext);
             if (httpContext.User.IsInRole("Admin")) return true;
           
            var id = httpContext.User.Identity.GetUserId();
           
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                //Implement you own DB logic here returning a true or false. 
                return context.Common.First(u => u.userid == id).UsuarioLogueado.Admin;
            }
        }
    }
