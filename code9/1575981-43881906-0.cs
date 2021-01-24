    public class BasicAuthorization : AuthorizeAttribute {
        public override void OnAuthorization(AuthorizationContext filterContext) {
            //see if we can skip the authorization
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                                     filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                                         typeof(AllowAnonymousAttribute), true);
    
            if (!skipAuthorization) {
                //Using dependency resolver here
                var userService = (IUserService) DependencyResolver.Current.GetService(typeof(IUserService));
                
    
                base.OnAuthorization(filterContext);
            }
        }
    }
