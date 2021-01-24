    public class AuthorizeActionFilterAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            IPrincipal user = HttpContext.Current.User; //get the current user
 
            //Get controller name and action
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            //All roles will be defined here!
            List<string> rolesAccepted = new List<string>();
            switch (controllerName){
                case "Controller1": //suppose these three happen to have the same rules
                case "Controller2":
                case "Controller3":
                    //Describe roles accepted for certain controller and action
                    rolesAccepted = new List<string> { "Role1", "Role2" };            
                    break;
                case "Controller4": //suppose these have specific restrictions only for some actions
                    if (actionName == "action1") {//can also use switch 
                        rolesAccepted = new List<string> { "Role3", "Role4" };
                    } else {
                        rolesAccepted = new List<string> { "Role5", "Role6", "Role7" };
                    }
                    break;
                ....
            }
            //Redirect to login if non of the user role is authorized
            if (!rolesAccepted.Any(x => user.IsInRole(x)){
                filterContext.Result = redirectToLogin();
                return;
            }
        }
    
        private ActionResult redirectToLogin() {
          return new RedirectToRouteResult(
              new RouteValueDictionary(new { controller = "Account", action = "Login" })
            );
        }
    
    }
