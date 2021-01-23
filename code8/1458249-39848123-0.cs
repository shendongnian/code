     sealed class AuthorizedRoles : ActionFilterAttribute
        {
           public string Roles { get; set; }
    
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var status = false;
                string[] roles = Roles.Split(',');
                var currentUserRole = Session.UserRole; // Get here the role of the user
                var Role = "";
                switch (currentUserRole)
                {
                    case 1:
                        Role = "Role1";
                        break;
                    case 2:
                        Role = "Role2";
                        break;
                    case 3:
                        Role = "Role3";
                        break; // Check here for more role
                    default:
                        break;
                }
    
              if (Role != ""){
                    foreach (var role in roles)
                    {
                        if (role.Contains(currentRoleName))
                        {
                            status = true;
                        }
                    }
                }
    
          if (status == false)//That means user is not in the role, so redirect it to the new controller returning a view showing information that you are not autorized
                {
                  if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        //The request can be ajax callso it will redirect to another ajax method
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "ControllerName",
                            action = "AjaxActionName",
                            area = ""
                        }));
                    }
                    else
                    {
               filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "ControllerName",
                            action = "ActionName",
                            area = ""
                        }));
    }
             }
          base.OnActionExecuting(filterContext);
            }
    
    }
